using UnityEngine;
using System.Collections; // Обязательно для использования IEnumerator

[RequireComponent(typeof(Rigidbody2D))] // Убедимся, что Rigidbody2D есть на объекте
[RequireComponent(typeof(Collider2D))] // Убедимся, что Collider2D есть на объекте
public class PickupMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 1.5f;             // Скорость горизонтального движения
    [SerializeField] private float pauseDuration = 1.0f;         // Время паузы на краях диапазона
    [SerializeField] private float movementRange = 0.5f;         // Радиус движения влево/вправо от центральной точки

    private Rigidbody2D _rb;
    private Vector3 _startPosition;
    private float _currentMovementTime;
    private float _currentPauseTime;
    private bool _isMovingRight = true;
    private bool _isPaused = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        // Устанавливаем Rigidbody2D в Kinematic, как вы указали
        _rb.bodyType = RigidbodyType2D.Kinematic;
        // Убедимся, что вращение по Z заморожено, если это важно
        _rb.freezeRotation = true;

        _startPosition = transform.position; // Запоминаем начальную позицию как центр движения
    }

    void Start()
    {
        // Сразу же начинаем движение вправо
        _isMovingRight = true;
        _currentMovementTime = 0f; // Сбрасываем таймер движения
        _currentPauseTime = 0f;    // Сбрасываем таймер паузы
        _isPaused = false;
    }

    void Update()
    {
        if (_isPaused)
        {
            // Если предмет на паузе, увеличиваем таймер паузы
            _currentPauseTime += Time.deltaTime;

            // Если время паузы истекло, переключаем состояние на движение
            if (_currentPauseTime >= pauseDuration)
            {
                Turn();
                _isPaused = false;
                _currentPauseTime = 0f; // Сбрасываем таймер паузы
                // Меняем направление движения
                _isMovingRight = !_isMovingRight;
            }
        }
        else
        {
            // Если предмет движется
            _currentMovementTime += Time.deltaTime;

            // Вычисляем новую позицию
            float horizontalMovement = moveSpeed * Time.deltaTime;
            if (!_isMovingRight) // Если движемся влево
            {
                horizontalMovement *= -1;
            }

            // Перемещаем объект
            transform.Translate(new Vector3(horizontalMovement, 0, 0));

            // Проверяем, не достигли ли мы края диапазона движения
            // Рассчитываем крайние точки относительно стартовой позиции
            Vector3 leftEdge = _startPosition - new Vector3(movementRange, 0, 0);
            Vector3 rightEdge = _startPosition + new Vector3(movementRange, 0, 0);

            // Если мы движемся вправо и достигли правого края, или движемся влево и достигли левого края
            if ((_isMovingRight && transform.position.x >= rightEdge.x) || (!_isMovingRight && transform.position.x <= leftEdge.x))
            {
                // Корректируем позицию, чтобы точно попасть на край, если движение прошло чуть дальше
                transform.position = _isMovingRight ? rightEdge : leftEdge;

                // Переходим в состояние паузы
                _isPaused = true;
                _currentMovementTime = 0f; // Сбрасываем таймер движения, хотя он тут уже не нужен до следующего движения
            }
        }
    }

    private void Turn()
    {
        //transform.localScale = new Vector2(-(Mathf.Sign(RB.linearVelocityX)), transform.localScale.y);
        transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);
    }

    // Для удобства отладки и визуализации диапазона движения в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 startPos = Application.isPlaying ? _startPosition : transform.position;
        Vector3 leftEdge = startPos - new Vector3(movementRange, 0, 0);
        Vector3 rightEdge = startPos + new Vector3(movementRange, 0, 0);

        Gizmos.DrawLine(leftEdge, rightEdge);
        Gizmos.DrawSphere(leftEdge, 0.1f);
        Gizmos.DrawSphere(rightEdge, 0.1f);
    }
}
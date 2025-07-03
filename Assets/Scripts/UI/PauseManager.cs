using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public GameObject pauseMenuUI;
    public GameObject playerGameObject;

    public bool IsPaused { get; private set; }

    public float Timer { get; private set; }

    private bool _pauseKeyPressed = false; // Флаг предотвращения многократного срабатывания
    private float _pauseCooldownTimer = 0f; // Таймер кулдауна паузы
    [SerializeField] private float _pauseCooldownDuration = 0.5f; // Длительность кулдауна в секундах

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // Важно, чтобы не продолжал инициализацию
        }

        Timer = 0f;
    }

    private void Update()
    {
        // Обновляем таймер кулдауна
        if (_pauseCooldownTimer > 0)
        {
            _pauseCooldownTimer -= Time.deltaTime;
        }

        // Проверяем нажатие клавиши Pause и кулдаун
        if (InputManager.PauseWasPressed && !_pauseKeyPressed && _pauseCooldownTimer <= 0)
        {
            _pauseKeyPressed = true;
            PauseGame();
            _pauseCooldownTimer = _pauseCooldownDuration; // Запускаем кулдаун
        }

        // Сбрасываем флаг при отпускании клавиши Pause
        if (!InputManager.PauseWasPressed)
        {
            _pauseKeyPressed = false;
        }

        if (!IsPaused)
        {
            Timer += Time.deltaTime;
        }
    }

    public void PauseGame()
    {
        //Выносим инвертирование логического состояния за пределы условий
        IsPaused = !IsPaused;
        Debug.Log("pause, now " + IsPaused);

        if (IsPaused)
        {
            Debug.Log("pause");
            Time.timeScale = 0f;

            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(true);
            }

            // Деактивируем игрока
            if (playerGameObject != null)
            {
                playerGameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Unpause");

            // Возобновляем время
            Time.timeScale = 1f;

            // Деактивируем UI паузы
            if (pauseMenuUI != null)
            {
                pauseMenuUI.SetActive(false);
            }

            // Активируем игрока
            if (playerGameObject != null)
            {
                playerGameObject.SetActive(true);
            }
        }
    }
}
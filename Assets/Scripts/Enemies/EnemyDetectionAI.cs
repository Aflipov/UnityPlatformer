using UnityEngine;

public class EnemyDetectionAI : MonoBehaviour
{
    public float detectionRange = 5f;
    public LayerMask obstacleLayer; // Слой, содержащий препятствия (стены, ящики и т.д.)
    public Transform player;

    private void Update()
    {
        // Направление на игрока
        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Проверка расстояния
        if (distanceToPlayer <= detectionRange)
        {
            // Raycast к игроку
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);

            // Проверка, попал ли Raycast в препятствие
            if (hit.collider == null)
            {
                // Игрок обнаружен!
                Debug.Log("Игрок обнаружен!");
            }
            else
            {
                // Препятствие на пути, игрок не виден
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

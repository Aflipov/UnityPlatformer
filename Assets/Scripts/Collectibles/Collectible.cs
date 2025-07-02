using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject collectEffect; // Префаб эффекта при сборе (например, частицы)

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что у игрока установлен тег "Player"
        {
            Collect(other.gameObject);
        }
    }

    protected virtual void Collect(GameObject player)
    {

    }
}

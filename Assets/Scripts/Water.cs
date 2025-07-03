using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Example: Check if it hits a player
        if (other.CompareTag("Player"))
        {
            //Apply Damage to Player (find healthSystem)
            PlayerHealthSystem healthSystem = other.GetComponent<PlayerHealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(666f);

            }
        }
    }
}

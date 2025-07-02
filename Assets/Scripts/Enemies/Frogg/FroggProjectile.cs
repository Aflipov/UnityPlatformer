using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float speed = 5f;
    public float lifeTime = 3f;  // Time until the projectile is destroyed

    private Rigidbody2D _rb;
    private Vector2 _direction; //Projectile Direction

    // Cache rigidbody for performance
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //Method to call the direction of projectile.
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SetGravityScale(float gravityScale)
    {
        _rb.gravityScale = gravityScale;
    }

    void Start()
    {
        //Set the velocity on start instead of fixed update.
        _rb.linearVelocity = _direction * speed;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Example: Check if it hits a player
        if (other.CompareTag("Player"))
        {
            //Apply Damage to Player (find healthSystem)
            PlayerHealthSystem healthSystem = other.GetComponent<PlayerHealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);

            }

            //Destroy the projectile on hit.
            Destroy(gameObject);
        }
    }
}
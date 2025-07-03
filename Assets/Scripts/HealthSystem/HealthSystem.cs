using UnityEngine;
using UnityEngine.Events; // Important for using UnityEvents

public class HealthSystem : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth;

    [Header("Events")]
    public UnityEvent OnHealthChanged;    // Called when health changes (takes no parameters)
    public UnityEvent OnDeath;

    private bool _isDead = false;

    // Custom UnityEvent for passing an integer (damage amount)
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }


    protected virtual void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(); // Initial call to update UI/other components
    }

    public virtual void TakeDamage(float amount)
    {
        if (_isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " took " + amount + " damage. Current health: " + currentHealth);

        OnHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (_isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //Debug.Log(gameObject.name + " healed for " + amount + ". Current health: " + currentHealth);

        OnHealthChanged?.Invoke();

    }

    protected virtual void Die()
    {
        if (_isDead) return; // Prevent multiple calls to Die

        Debug.Log(gameObject.name + " died!");
        _isDead = true;

        OnDeath?.Invoke();  // Call the death event (listeners can handle destruction/respawn etc.)
    }

    //Public method to restore all health
    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        _isDead = false;

        OnHealthChanged?.Invoke();
        GetComponent<Collider2D>().enabled = true;
    }

    //Public accessors
    public float GetCurrentHealth() { return currentHealth; }

    public float GetMaxHealth() { return maxHealth; }

    public bool IsDead() { return _isDead; }
}
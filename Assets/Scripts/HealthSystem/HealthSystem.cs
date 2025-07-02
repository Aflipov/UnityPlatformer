using UnityEngine;
using UnityEngine.Events; // Important for using UnityEvents

public class HealthSystem : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;

    [Header("Events")]
    public UnityEvent OnHealthChanged;    // Called when health changes (takes no parameters)
    public UnityEvent OnDeath;             // Called when health reaches zero (takes no parameters)
    public IntEvent OnDamageTaken;         // Called when damage is taken. Passes the damage amount.
    public IntEvent OnHealed;            //Called when healed. Passes the healed amount

    private bool _isDead = false;

    // Custom UnityEvent for passing an integer (damage amount)
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }


    protected virtual void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(); // Initial call to update UI/other components
    }

    public virtual void TakeDamage(int damage)
    {
        if (_isDead) return; // Prevent taking damage after death

        int clampedDamage = Mathf.Abs(damage); // Ensure damage is positive

        currentHealth -= clampedDamage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Keep health within bounds

        Debug.Log(gameObject.name + " took " + clampedDamage + " damage. Current health: " + currentHealth);

        OnHealthChanged?.Invoke();
        OnDamageTaken?.Invoke(clampedDamage);  // Call event, passing damage amount

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (_isDead) return; //Prevent healing after death

        int clampedAmount = Mathf.Abs(amount);

        currentHealth += clampedAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " healed for " + amount + ". Current health: " + currentHealth);

        OnHealthChanged?.Invoke();
        OnHealed?.Invoke(clampedAmount);

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
    public int GetCurrentHealth() { return currentHealth; }

    public int GetMaxHealth() { return maxHealth; }

    public float GetHealthNormalized() { return (float)currentHealth / maxHealth; } //Get health in percentage
    public bool IsDead() { return _isDead; }
}
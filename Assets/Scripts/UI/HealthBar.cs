using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealthSystem playerHealthSystem;
    public Slider healthSlider;
    public Slider easeHealthSlider;

    public float maxHealth;
    public float health;
    public float lerpSpeed;

    void Start()
    {
        playerHealthSystem.OnHealthChanged.AddListener(OnHealthChanged);

        health = maxHealth = playerHealthSystem.GetMaxHealth();
    }

    //private void OnEnable()
    //{
    //    if (playerHealthSystem != null)
    //    {
    //        playerHealthSystem.OnHealthChanged.AddListener(OnHealthChanged);
    //        // healthSystem.OnHealed.AddListener(OnHealed);
    //    }
    //}

    //private void OnDisable()
    //{
    //    if (playerHealthSystem != null)
    //    {
    //        playerHealthSystem.OnHealthChanged.RemoveListener(OnHealthChanged);
    //        // healthSystem.OnHealed.RemoveListener(OnHealed);
    //    }
    //}

    public void OnHealthChanged()
    {
        health = playerHealthSystem.GetCurrentHealth();
    }

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (easeHealthSlider.value > healthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
        else if (easeHealthSlider.value < healthSlider.value)
        {
            easeHealthSlider.value = health;
        }
    }
}

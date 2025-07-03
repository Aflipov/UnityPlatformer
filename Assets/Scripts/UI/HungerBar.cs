using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public HungerSystem playerHungerSystem;
    public Slider hungerSlider;
    public Slider easeHungerSlider;

    public float maxHunger;
    public float currentHunger;
    public float lerpSpeed;

    void Start()
    {
        playerHungerSystem.OnHungerChanged.AddListener(OnHungerChanged);

        currentHunger = maxHunger = playerHungerSystem.GetMaxHunger();

        hungerSlider.maxValue = maxHunger;
        hungerSlider.minValue = 0f;
    }

    //private void OnEnable()
    //{
    //    if (playerHungerSystem != null)
    //    {
    //        playerHungerSystem.OnHungerChanged.AddListener(OnHungerChanged);
    //        // healthSystem.OnHealed.AddListener(OnHealed);
    //    }
    //}

    //private void OnDisable()
    //{
    //    if (playerHungerSystem != null)
    //    {
    //        playerHungerSystem.OnHungerChanged.RemoveListener(OnHungerChanged);
    //        // healthSystem.OnHealed.RemoveListener(OnHealed);
    //    }
    //}

    public void OnHungerChanged()
    {
        currentHunger = playerHungerSystem.GetCurrentHunger();
    }

    void Update()
    {
        if (hungerSlider.value != currentHunger)
        {
            hungerSlider.value = currentHunger;
        }

        if (easeHungerSlider.value < hungerSlider.value)
        {
            easeHungerSlider.value = Mathf.Lerp(easeHungerSlider.value, currentHunger, lerpSpeed);
        }
        else if (easeHungerSlider.value > hungerSlider.value)
        {
            easeHungerSlider.value = currentHunger;
        }
    }
}

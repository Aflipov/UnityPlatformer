using UnityEngine;
using UnityEngine.Events;

public class HungerSystem : MonoBehaviour
{
	[Header("Hunger Parameters")]
	[SerializeField] private float maxHunger = 100;
	[SerializeField] private float currentHunger;

	[Header("Events")]
	public UnityEvent OnHungerChanged;


	private void Start()
	{
		currentHunger = maxHunger;
		OnHungerChanged?.Invoke();
	}

	private void Update()
	{
    }

	public void Starve(float amount)
	{
		currentHunger = Mathf.Clamp(currentHunger - amount, 0f, maxHunger);

        OnHungerChanged?.Invoke();
    }

    public void RefillHunger()
    {
        currentHunger = maxHunger;

        OnHungerChanged?.Invoke();
    }

    public void RestoreHunger(float amount)
	{
        currentHunger = Mathf.Clamp(currentHunger +amount, 0f, maxHunger);

        OnHungerChanged?.Invoke();
    }

	public float GetCurrentHunger() { return currentHunger; }

	public float GetMaxHunger() { return maxHunger; }
}
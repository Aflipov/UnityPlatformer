using UnityEngine;
using UnityEngine.Events;

public class HungerSystem : MonoBehaviour
{
	[Header("Hunger Parameters")]
	[SerializeField] private float maxHunger = 100;
	[SerializeField] private float currentHunger;
	[SerializeField] private float starvingSpeed;

	[Header("Events")]
	public UnityEvent OnHungerChanged;


	private void Start()
	{
		currentHunger = maxHunger;
		OnHungerChanged?.Invoke();
	}

	private void Update()
	{
		Starve();

    }

	private void Starve()
	{
		currentHunger = Mathf.Clamp(currentHunger - starvingSpeed * Time.deltaTime, 0f, maxHunger);
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

	public float GetStarvingSpeed() { return starvingSpeed; }
}
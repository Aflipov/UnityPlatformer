using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
	[SerializeField] private float regenDelay = 5f;
	public float regenPerSec = 10f;

	private HungerSystem hungerSystem;
	private float timeToRegenStart = 0f;
	private bool isRegenerating = false;

	protected override void Start()
	{
		hungerSystem = GetComponent<HungerSystem>();
		base.Start();
	}

	private void Update()
	{
		RegenerateCheck();

        if (isRegenerating)
        {
			Regenerate(regenPerSec * Time.deltaTime);
        }
	}

	private void RegenerateCheck()
	{
		timeToRegenStart = Mathf.Clamp(timeToRegenStart - Time.deltaTime, 0f, regenDelay);

		if (currentHealth < maxHealth && hungerSystem.GetCurrentHunger() > 0f && timeToRegenStart == 0f && !isRegenerating)
		{
			isRegenerating = true;
		}
		else
		{
			isRegenerating = false;
		}
	}
	private void Regenerate(float amount)
	{
		Heal(amount);

		hungerSystem.Starve(amount);
	}


	protected override void Die()
	{
		base.Die();

		SceneSwapManager.SwapScene("MainMenu");
	}

	public override void TakeDamage(float damage)
	{
		timeToRegenStart = regenDelay;

		base.TakeDamage(damage);
	}
}

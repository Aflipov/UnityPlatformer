using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeEnemyHealthSystem : HealthSystem
{
	//[Header("Animation")]
	
	[Header("Animation")]
    public Animator animator;
	[SerializeField] private string deathAnimationName = "Death";
	public float deathAnimationDuration = 1.0f;

	[Header("Loot")]
	public List<GameObject> lootDrops = new List<GameObject>();
	[Range(0f, 1f)]
	public float dropChance = 0.5f;

	[Header("Events")]
	//public GameEvent OnEnemyDeath;

	//Optional Cache
	private Collider2D _collider;
	private DamageFlash damageFlash;


	protected override void Start()
	{
		base.Start();

		if (animator == null)
		{
			animator = GetComponent<Animator>();
			if (animator == null)
			{
				Debug.LogError("No animator on the current object");
			}
		}

		// Optional, cache the collider for performance
		_collider = GetComponent<Collider2D>();
        damageFlash = GetComponent<DamageFlash>();
    }

    public override void TakeDamage(int damage)
    {
		damageFlash.Flash();
        base.TakeDamage(damage);
    }


	//Override death method
	protected override void Die()
	{
		if (IsDead()) return; // Prevent multiple calls to Die

		Debug.Log("Enemy died! Dropping loot and triggering death event...");

		DropLoot();
		PlayDeathAnimation();
		DisableCollider();

		//OnEnemyDeath?.Raise();

		base.Die();
	}

	private void DropLoot()
	{
		if (Random.value <= dropChance && lootDrops.Count > 0)
		{
			int randomIndex = Random.Range(0, lootDrops.Count);
			GameObject loot = Instantiate(lootDrops[randomIndex], transform.position, Quaternion.identity);
		}
	}

	private void PlayDeathAnimation()
	{
		if (animator != null)
		{
			animator.Play(deathAnimationName, -1, 0f); //Trigger animation
			SelfDestroy();
			
		}
		else
		{
			Debug.LogWarning("Animator is null. Death animation will not play.");
		}
	}

	private void DisableCollider()
	{
		//Disable collider for the object
		if (_collider != null)
		{
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			_collider.enabled = false;
		}
		else
		{
			Debug.LogWarning("Collider is null. Collision is not disabled");
			GetComponent<Collider2D>().enabled = false; //Prevent collision
		}
	}

    public void SelfDestroy()
    {
		StartCoroutine(SelfDestroyCoroutine());
    }

    IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
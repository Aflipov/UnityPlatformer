using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
	[Header("Attack Parameters")]
	[SerializeField] private float attackRange = 1f; // Radius of the attack circle
	[SerializeField] private int attackDamage = 20;
	[SerializeField] private float attackCooldown = 0.5f; // Time between attacks
	[SerializeField] private LayerMask enemyLayers;      // Target enemy layers

	[Header("References")]
	[SerializeField] private Animator animator;          // Player Animator component
	[SerializeField] private string attackAnimationName = "Attack";  // Name of the attack animation
	//[SerializeField] private CircleCollider2D attackCollider; // The trigger collider
    [SerializeField] private Transform attackPoint;     // Position of attack

	private float _nextAttackTime = 0f; // Time available for next attack


	void Update()
	{
		if (Time.time >= _nextAttackTime)
		{
			//if (Input.GetKeyDown(KeyCode.Space)) // Change to your attack input key
			if (InputManager.AttackWasPressed) // Change to your attack input key
			{
				MeleeAttack();
				_nextAttackTime = Time.time + attackCooldown;
			}
		}
	}

    //private void MeleeAttack()
    //{
    //	//1. Play attack animation
    //	//animator.SetTrigger(attackAnimationName);

    //       animator.Play(attackAnimationName, -1, 0f);

    //       //2. Activate the trigger collider (to detect hits)
    //       if (attackCollider != null)
    //	{
    //		attackCollider.enabled = true;  // Enable the collider
    //	}

    //	//3. (Optional) Disable the collider after a short delay (matching the animation)
    //	Invoke(nameof(DisableAttackCollider), 0.25f); // Adjust delay to match the animation
    //}

    private void MeleeAttack()
    {
        //1. Play attack animation
        animator.Play(attackAnimationName, -1, 0f);

        //2. Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //3. Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);

            //Try to find component that will take damage and apply damage. Replace code with your own
            if (enemy.TryGetComponent<HealthSystem>(out var healthSystem))
            {
                healthSystem.TakeDamage(attackDamage);
            }

            //Another way to take damage if you can not find healthSystem
            /*
            Enemy currentEnemy = enemy.GetComponent<Enemy>();
            if (currentEnemy != null)
            {
                currentEnemy.TakeDamage(attackDamage);
            }
            */
        }
    }

    // Called after a delay (set in the MeleeAttack method)
 //   private void DisableAttackCollider()
	//{
	//	if (attackCollider != null)
	//	{
	//		attackCollider.enabled = false; // Disable the collider
	//	}
	//}

	// Handle collisions with the attack trigger
	private void OnTriggerEnter2D(Collider2D other)
	{
        //Debug.Log("Hit " + other.name);
        // Check if the other object is an enemy
        if (other.gameObject.layer == enemyLayers) //Check the LayerMask
		{
			Debug.Log("Hit " + other.name);

			// Apply damage to the enemy (example: find HealthSystem)
			//HealthSystem healthSystem = other.GetComponent<HealthSystem>();
			//if (healthSystem != null)
			//{
			//    healthSystem.TakeDamage(attackDamage);
			//}
		}
		else
		{
            //Debug.Log("Not Hit " + other.name);
        }
	}

    //(Optional) Visualise the attack range in the editor(if not using a visual collider)
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

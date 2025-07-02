using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy: MonoBehaviour
{
	[Header("References")]
	//[SerializeField] public Collider2D _bodyColl;
	//[SerializeField] public Collider2D _edgeColl;
	public Transform raycastOrigin;
	[SerializeField] protected SOEnemyData enemyData;
	public Rigidbody2D RB { get; private set; }
	public Animator Animator { get; private set; }
	//protected SpriteRenderer spriteRenderer;

	public LayerMask groundLayer;
	public LayerMask obstacleLayer; // Слой, содержащий препятствия (стены, ящики и т.д.)
	public Transform player;

	protected int currentHealth;

	public float distanceToPlayer;
	public Vector2 directionToPlayer;

    public bool playerDetected;



	protected virtual void Awake()
	{
		currentHealth = enemyData.maxHealth;
		player = GameObject.Find("Player").transform;
	}

	protected virtual void Start()
	{
		Animator = GetComponent<Animator>();
		RB = GetComponent<Rigidbody2D>();
		//spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected virtual void Update()
	{
		DetectPlayer();
	}

	protected virtual void FixedUpdate()
	{
	}

	public bool IsFacingRight()
	{
		return transform.localScale.x > Mathf.Epsilon;
	}

	public void Turn()
	{
		//transform.localScale = new Vector2(-(Mathf.Sign(RB.linearVelocityX)), transform.localScale.y);
		transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);
	}

	public virtual void Patrol()
	{
		if (IsFacingRight())
		{
			RB.linearVelocityX = enemyData.moveSpeed;
		}
		else
		{
			RB.linearVelocityX = -enemyData.moveSpeed;
		}
	}

	public virtual void Stop()
	{
        RB.linearVelocityX = 0f;
    }

	protected virtual void DetectPlayer()
	{
		// Направление на игрока
		directionToPlayer = player.position - transform.position;
		distanceToPlayer = directionToPlayer.magnitude;

		if (distanceToPlayer <= enemyData.detectionRange && !player.GetComponent<PlayerHealthSystem>().IsDead())
		{

			// Raycast к игроку
			RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
            Debug.DrawRay(transform.position, directionToPlayer, playerDetected ? Color.green : Color.red);
            // Проверка, попал ли Raycast в препятствие
            if (hit.collider == null)
			{
				// Игрок обнаружен!
				playerDetected = true;
			}
			else
			{
				playerDetected = false;
			}
		}
        else
        {
			playerDetected = false;
        }
    }

	protected void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, enemyData.detectionRange);
	}
}
using System.Collections;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMele : Enemy
{
	public EnemyFSM<EnemyMele> StateMachine;
	public MelePatrolState PatrolState { get; private set; }
	public MeleFightState FightState { get; private set; }


	public RaycastHit2D groundHit;
	public RaycastHit2D wallHit;

	public bool nearEdge;
	public bool nearWall;

    public GameObject projectilePrefab;  // Assign your projectile prefab here
    public Transform firePoint;           // Point where the projectile will spawn (child object)
    public float fireRate = 2f;           // Time between shots
    public float projectileSpeed = 5f;   // Projectile speed
    public int projectileDamage = 10; // Add the Damage Field
    public float projectileLifetime = 3f;  //add the life time
    public float gravityScale = 0.5f;

    private float _nextFireTime;

    protected override void Awake()
	{
		base.Awake();

		StateMachine = new EnemyFSM<EnemyMele>();

		PatrolState = new MelePatrolState(this, StateMachine, enemyData, "Move");
		FightState = new MeleFightState(this, StateMachine, enemyData, "Idle");
	}

	protected override void Start()
	{
		base.Start();

		StateMachine.Initialize(PatrolState);
	}

	protected override void Update()
	{
		base.Update();

		StateMachine.CurrentState.LogicUpdate();
	}

	protected override void FixedUpdate()
	{
		base .FixedUpdate();

		StateMachine.CurrentState.PhysicsUpdate();
	}

	public void isNearEdge()
	{
		groundHit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, enemyData.groundRayLngth, groundLayer);
		if (groundHit.collider == null) // Если Raycast не попал в платформу
		{
			nearEdge = true; // Значит, мы рядом с краем
		}
		else
		{
			nearEdge = false; // Значит, мы не рядом с краем
		}

		Debug.DrawRay(raycastOrigin.position, Vector2.down * enemyData.groundRayLngth, nearEdge ? Color.red : Color.green);
	}

	public void isNearWall()
	{
		if (IsFacingRight())
		{
			wallHit = Physics2D.Raycast(RB.position, Vector2.right, enemyData.wallRayLngth, groundLayer);	
			Debug.DrawRay(RB.position, Vector2.right * enemyData.wallRayLngth, !nearWall ? Color.red : Color.green);
		}
		else
		{
			wallHit = Physics2D.Raycast(RB.position, Vector2.left, enemyData.wallRayLngth, groundLayer);
			Debug.DrawRay(RB.position, Vector2.left * enemyData.wallRayLngth, !nearWall ? Color.red : Color.green);
		}
		if (wallHit.collider != null) // Если Raycast попал в стену
		{
			nearWall = true; // Значит, мы рядом со стеной
		}
		else
		{
			nearWall = false; // Значит, мы не рядом со стеной
		}
	}

	public override void Patrol()
	{
		if (nearEdge || nearWall)
		{
			Turn();
		}

		base.Patrol();
	}

	public void Cooldown()
	{
        if (Time.time > _nextFireTime)
        {
            InitiateShot();
            _nextFireTime = Time.time + 1f / fireRate; //Fire every rate
        }
    }

	public void InitiateShot()
	{
		StartCoroutine(ShotInitiationCoroutine());
	}

	IEnumerator ShotInitiationCoroutine()
	{ 
        Animator.Play("Attack", -1, 0f);

		yield return new WaitForSeconds(0.2f);

        //Calculate direction from enemy to player
        Vector2 direction = (player.position - firePoint.position).normalized;

        //Create Projectile
        GameObject projectileObj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        //Set the projectile direction.
        projectile.SetDirection(direction);

        //Set the projectile Speed and Damage.  Do this *after* instantiating
        projectile.speed = projectileSpeed;
        projectile.damage = projectileDamage;
        projectile.lifeTime = projectileLifetime;
        projectile.SetGravityScale(gravityScale); //Custom gravity.
    }
}

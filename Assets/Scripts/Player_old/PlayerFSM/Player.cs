using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
	#region SFM
	public PlayerStateMachine StateMachine { get; private set; }

	public PlayerIdleState IdleState { get; private set; }
	public PlayerMoveState MoveState { get; private set; }
	public PlayerMoveState DashState { get; private set; }

	#endregion

	#region Components

	[Header("References")]
	public SOPlayerMovementStats MoveStats;
	[SerializeField] private Collider2D _feetColl;
	[SerializeField] private Collider2D _bodyColl;
	public Rigidbody2D RB;
	public Animator Animator { get; private set; }
	public PlayerInputHandler InputHandler { get; private set; }
	private SpriteRenderer spriteRenderer;

	#endregion

	#region Variables

	//movement vars
	public float HorizontalVelocity { get; private set; }

	//jump vars
	public float VerticalVelocity { get; private set; }

	#endregion

	private void Awake()
	{
		StateMachine = new PlayerStateMachine();

		IdleState = new PlayerIdleState(this, StateMachine, MoveStats, "Idle");
		MoveState = new PlayerMoveState(this, StateMachine, MoveStats, "Move");
		DashState = new PlayerMoveState(this, StateMachine, MoveStats, "Dash");
	}

	private void Start()
	{
		Animator = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		StateMachine.Initialize(IdleState);
	}

	private void Update()
	{
		StateMachine.CurrentState.LogicUpdate();
	}

	private void FixedUpdate()
	{
		StateMachine.CurrentState.PhysicsUpdate();

		ApplyVelocity();
	}

	public void TurnCheck()
	{
		if (InputHandler.xInput < 0)
		{
			spriteRenderer.flipX = true;
		}
		else if (InputHandler.xInput > 0)
		{
			spriteRenderer.flipX = false;
		}
	}
	private void ApplyVelocity()
	{
		//CLAMP FALL SPEED
		if (StateMachine.CurrentState == DashState)
		{
			VerticalVelocity = Mathf.Clamp(VerticalVelocity, -MoveStats.MaxFallSpeed, 50f);
		}

		else
		{
			VerticalVelocity = Mathf.Clamp(VerticalVelocity, -50f, 50f);
		}

		RB.linearVelocity = new Vector2(HorizontalVelocity, VerticalVelocity);
	}
}

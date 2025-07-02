using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState
{
	protected Player player;
	protected PlayerStateMachine stateMachine;
	protected SOPlayerMovementStats moveStats;

	protected float startTime;

	private string animStateName;
	
	protected float xInput;


	public PlayerState(Player player, PlayerStateMachine stateMachine, SOPlayerMovementStats moveStats, string animStateName)
	{
		this.player = player;
		this.stateMachine = stateMachine;
		this.moveStats = moveStats;
		this.animStateName = animStateName;
	}

	public virtual void Enter()
	{
		DoChecks();
		player.Animator.Play(animStateName);
		startTime = Time.time;
		Debug.Log(animStateName);
	}

	public virtual void Exit()
	{
	}

	public virtual void LogicUpdate()
	{
		xInput = player.InputHandler.xInput;
	}

	public virtual void PhysicsUpdate()
	{
		DoChecks();
	}

	public virtual void DoChecks()
	{
		
	}

	
}

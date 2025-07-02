using UnityEngine;

public class EnemyState<T> where T : Enemy
{
	protected T enemy;
	protected EnemyFSM<T> stateMachine;
	protected SOEnemyData enemyData;

	protected float startTime;

	private string animStateName;


	public EnemyState(T enemy, EnemyFSM<T> stateMachine, SOEnemyData enemyData, string animStateName)
	{
		this.enemy = enemy;
		this.stateMachine = stateMachine;
		this.enemyData = enemyData;
		this.animStateName = animStateName;
	}

	public virtual void Enter()
	{
		DoChecks();
		enemy.Animator.Play(animStateName);
		startTime = Time.time;
	}

	public virtual void Exit()
	{
	}

	public virtual void LogicUpdate()
	{
	}

	public virtual void PhysicsUpdate()
	{
		DoChecks();
	}

	public virtual void DoChecks()
	{

	}
}

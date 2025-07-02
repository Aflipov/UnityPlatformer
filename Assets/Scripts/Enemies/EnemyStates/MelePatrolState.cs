using Unity.VisualScripting;
using UnityEngine;

public class MelePatrolState : EnemyState<EnemyMele>
{
	public MelePatrolState(EnemyMele enemy, EnemyFSM<EnemyMele> stateMachine, SOEnemyData enemyData, string animStateName) : base(enemy, stateMachine, enemyData, animStateName)
	{
	}

	public override void DoChecks()
	{
		base.DoChecks();
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

        if (enemy.playerDetected)
        {
            stateMachine.ChangeState(enemy.FightState);
			return;
        }

        enemy.isNearEdge();
        enemy.isNearWall();
        enemy.Patrol();
    }

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}

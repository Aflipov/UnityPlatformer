using UnityEngine;

public class EnemyMeleState : EnemyState<EnemyMele>
{
    public EnemyMeleState(EnemyMele enemy, EnemyFSM<EnemyMele> stateMachine, SOEnemyData enemyData, string animStateName) : base(enemy, stateMachine, enemyData, animStateName)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

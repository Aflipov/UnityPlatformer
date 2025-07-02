using UnityEngine;

public class MeleFightState : EnemyState<EnemyMele>
{
    public MeleFightState(EnemyMele enemy, EnemyFSM<EnemyMele> stateMachine, SOEnemyData enemyData, string animStateName) : base(enemy, stateMachine, enemyData, animStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.Stop();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Mathf.Sign(enemy.directionToPlayer.x) != Mathf.Sign(enemy.transform.localScale.x))
            {
            enemy.Turn();
        }

        if (!enemy.playerDetected)
        {
            stateMachine.ChangeState(enemy.PatrolState);
            return;
        }

        enemy.Cooldown();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

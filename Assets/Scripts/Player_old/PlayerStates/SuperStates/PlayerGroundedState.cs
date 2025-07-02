using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, SOPlayerMovementStats moveStats, string animStateName) : base(player, stateMachine, moveStats, animStateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        player.TurnCheck();
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

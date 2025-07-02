using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, SOPlayerMovementStats moveStats, string animStateName) : base(player, stateMachine, moveStats, animStateName)
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

        if (xInput == 0f)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        //player.RB.AddForceX(xInput * playerData.moveSpeed);
        //player.RB.linearVelocityX = xInput * playerData.moveSpeed * Time.fixedDeltaTime;
    }
}

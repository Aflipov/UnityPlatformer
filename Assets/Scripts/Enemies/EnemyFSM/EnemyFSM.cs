using UnityEngine;

public class EnemyFSM<T> where T : Enemy
{
    public EnemyState<T> CurrentState { get; private set; }

    public void Initialize(EnemyState<T> startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState<T> newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}

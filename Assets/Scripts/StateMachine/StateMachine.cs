using UnityEngine;

public class StateMachine
{
    // Current state
    private State currentState;
    public string currentStateName { get; private set; }

    // Update, LateUpdate, FixedUpdate
    public void Update()
    {
        currentState?.Update();
    }

    public void LateUpdate()
    {
        currentState?.LateUpdate();
    }

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    // Changestate
    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentStateName = newState?.name;
        newState?.Enter();
    }
}
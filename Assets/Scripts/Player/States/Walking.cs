using UnityEngine;

public class Walking : State
{
    private PlayerController controller;

    public Walking(PlayerController controller) : base("Walking")
    {
        this.controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void LateUpdate()
    {
        base.LateUpdate();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Switch to Jump
        if (controller.hasJumpInput)
        {
            controller.stateMachine.ChangeState(controller.jumpState);
            return;
        }

        // Switch to Idle
        if (controller.movementVector.IsZero())
        {
            controller.stateMachine.ChangeState(controller.idleState);
            return;
        }

        // Create movement vector
        Vector3 walkVector = new(controller.movementVector.x, 0, controller.movementVector.y);
        walkVector = controller.GetForwardDirection() * walkVector;
        walkVector *= controller.movementSpeed;

        // Apply input to character
        controller.thisRigidBody.AddForce(walkVector, ForceMode.Force);

        // Rotate character
        controller.RotateBodyToFaceInput();
    }
}
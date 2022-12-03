using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJump : PlayerStateBase
{
    public override void Enter()
    {
        _stateMachine.PlayerController.Jump();
    }

    public override void Exit()
    {
        // ‰½‚à‚µ‚È‚¢
    }

    public override void Update()
    {
        if (_stateMachine.PlayerController.GroundedChecker.IsGrounded)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
                _stateMachine.TransitionTo(_stateMachine.StateMove);
            else
                _stateMachine.TransitionTo(_stateMachine.StateIdle);
        }
    }
}

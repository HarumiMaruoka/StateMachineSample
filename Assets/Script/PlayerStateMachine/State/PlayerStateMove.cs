using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerStateBase
{
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        _stateMachine.PlayerController.Move();
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1f)
            _stateMachine.TransitionTo(_stateMachine.StateIdle);
        if (Input.GetButtonDown("Jump"))
            _stateMachine.TransitionTo(_stateMachine.StateJump);
    }
}

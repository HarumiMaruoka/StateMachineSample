using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    public override void Enter()
    {
        // �������Ȃ�
    }

    public override void Exit()
    {
        // �������Ȃ�
    }

    public override void Update()
    {
        // �ړ����͂��������Ƃ��AMoveState�ɑJ�ڂ���
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
            _stateMachine.TransitionTo(_stateMachine.StateMove);
        // �ڒn���Ă����� ���� �W�����v���͂��������Ƃ��AJumpState�ɑJ�ڂ���
        if (Input.GetButtonDown("Jump"))
            _stateMachine.TransitionTo(_stateMachine.StateJump);
    }
}

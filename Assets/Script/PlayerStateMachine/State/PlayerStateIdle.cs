using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    new public void Init(PlayerStateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
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

        // �ڒn���Ă����� ���� �W�����v���͂��������Ƃ��AJumpState�ɑJ�ڂ���

    }
}

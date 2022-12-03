using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    public override void Enter()
    {
        // 何もしない
    }

    public override void Exit()
    {
        // 何もしない
    }

    public override void Update()
    {
        // 移動入力があったとき、MoveStateに遷移する
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
            _stateMachine.TransitionTo(_stateMachine.StateMove);
        // 接地している状態 かつ ジャンプ入力があったとき、JumpStateに遷移する
        if (Input.GetButtonDown("Jump"))
            _stateMachine.TransitionTo(_stateMachine.StateJump);
    }
}

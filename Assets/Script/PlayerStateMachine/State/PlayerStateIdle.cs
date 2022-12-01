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
        // 何もしない
    }

    public override void Exit()
    {
        // 何もしない
    }

    public override void Update()
    {
        // 移動入力があったとき、MoveStateに遷移する

        // 接地している状態 かつ ジャンプ入力があったとき、JumpStateに遷移する

    }
}

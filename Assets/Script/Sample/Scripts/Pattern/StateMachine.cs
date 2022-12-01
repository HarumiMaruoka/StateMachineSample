using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    // handles
    [Serializable]
    public class StateMachine
    {
        // 現在のステートを表す変数
        public IState CurrentState { get; private set; }

        // 各ステートの参照変数（すべてIStateを継承している。）
        public WalkState walkState;
        public JumpState jumpState;
        public IdleState idleState;

        // ステートが変更されたときに実行するメソッド
        public event Action<IState> stateChanged;

        // コンストラクタ。
        public StateMachine(PlayerController player)
        {
            // ステートのインスタンスを生成し、参照を変数に保存する。
            this.walkState = new WalkState(player);
            this.jumpState = new JumpState(player);
            this.idleState = new IdleState(player);
        }

        // 最初のステートを設定する。
        public void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();

            // ステート変化時に実行するアクション。
            // 引数に最初のステートを渡す。
            stateChanged?.Invoke(state);
        }

        // ステートの遷移処理。引数に「次のステートの参照」を受け取る。
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();      // 現在ステートの終了処理。
            CurrentState = nextState; // 現在のステートの変更処理。
            nextState.Enter();        // 変更された「新しい現在ステート」のEnter処理。

            // ステート変更時のアクションを実行する。
            // 引数に「新しい現在ステート」を渡す。
            stateChanged?.Invoke(nextState);
        }

        // 現在ステートの更新処理を実行
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}

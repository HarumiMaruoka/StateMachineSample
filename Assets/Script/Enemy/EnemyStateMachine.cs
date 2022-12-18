using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // 状態を表す列挙型
    public enum State
    {
        Idle,
        Move,
        Attack
    }

    // 現在の状態
    public State currentState = State.Idle;

    // 状態を切り替えるための関数
    public void ChangeState(State newState)
    {
        // 現在の状態を終了する
        OnExitState(currentState);

        // 現在の状態を更新する
        currentState = newState;

        // 新しい状態を開始する
        OnEnterState(currentState);
    }

    // 状態が開始されるときに呼び出される関数
    public void OnEnterState(State state)
    {
        switch (state)
        {
            case State.Idle:
                // 待機状態の処理
                break;
            case State.Move:
                // 移動状態の処理
                break;
            case State.Attack:
                // 攻撃状態の処理
                break;
        }
    }

    // 状態が終了されるときに呼び出される関数
    public void OnExitState(State state)
    {
        switch (state)
        {
            case State.Idle:
                // 待機状態の終了処理
                break;
            case State.Move:
                // 移動状態の終了処理
                break;
            case State.Attack:
                // 攻撃状態の終了処理
                break;
        }
    }

    // 毎フレーム呼び出される関数
    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                // 待機状態の更新処理
                break;
            case State.Move:
                // 移動状態の更新処理
                break;
            case State.Attack:
                // 攻撃状態の更新処理
                break;
        }
    }
}
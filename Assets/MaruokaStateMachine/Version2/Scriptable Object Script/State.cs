using System;
using UnityEngine;

/// <summary>
/// ステートの基底クラス
/// </summary>
public abstract class State : ScriptableObject
{
    [Tooltip("条件と遷移先の組み合わせ"), SerializeField]
    private Transition[] _transitions = default;

    /// <summary>
    /// 主にこの値にアクセスして、独自の処理を実装する。
    /// </summary>
    protected SelfMadeStateMachine _owner = null;

    /// <summary>
    /// オーナーを設定し、
    /// 複製元とフィールドの状況を統一する。
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="sourceObj"></param>
    public void Setup(SelfMadeStateMachine owner, State sourceObj)
    {
        _owner = owner;
        _transitions = sourceObj._transitions;
    }
    /// <summary>
    /// Enter処理の強制実行。
    /// ステートマシンで,最初のステートを割り当てる時に実行する必要があったが、<br/>
    /// Enterを直接公開したくなかったので仕方なくこの形にした。
    /// 何かいい案があったら持ってきてください。
    /// </summary>
    public void ExecuteEnter()
    {
        Enter();
    }
    /// <summary>
    /// ステートマシンから毎フレーム更新する。
    /// </summary>
    public void Execute()
    {
        Update();
        OnTransition();
    }
    /// <summary>
    /// 条件をチェックし、条件が満たされたらステートを遷移する。
    /// </summary>
    private void OnTransition()
    {
        // 全ての遷移条件をチェックする
        for (int i = 0; i < _transitions.Length; i++)
        {
            // ステートマシンの状態を確認し、条件が成立していたら遷移する
            if (_owner.Conditions.HasFlag(_transitions[i].Conditions))
            {
                // 旧ステートのExit処理を実行
                _owner.CurrentState.Exit();
                // ステートを更新
                _owner.ChangeState(_transitions[i].NextState);
                // 新ステートのEnter処理を実行
                _owner.CurrentState.Enter();
                // ステートマシンの状態をリセット
                _owner.Conditions = Conditions.None;
                return;
            }
        }
    }

    protected abstract void Enter();
    protected abstract void Update();
    protected abstract void Exit();

    /// <summary>
    /// 条件と遷移先の組み合わせ
    /// </summary>
    [Serializable]
    private class Transition
    {
        [SerializeField]
        private Conditions _conditions = default;
        [SerializeField]
        private State _nextState = default;

        public Conditions Conditions => _conditions;
        public State NextState => _nextState;
    }
}

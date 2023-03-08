using System;
using UnityEngine;

/// <summary>
/// �X�e�[�g�̊��N���X
/// </summary>
public abstract class State : ScriptableObject
{
    [Tooltip("�����ƑJ�ڐ�̑g�ݍ��킹"), SerializeField]
    private Transition[] _transitions = default;

    /// <summary>
    /// ��ɂ��̒l�ɃA�N�Z�X���āA�Ǝ��̏�������������B
    /// </summary>
    protected SelfMadeStateMachine _owner = null;

    /// <summary>
    /// �I�[�i�[��ݒ肵�A
    /// �������ƃt�B�[���h�̏󋵂𓝈ꂷ��B
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="sourceObj"></param>
    public void Setup(SelfMadeStateMachine owner, State sourceObj)
    {
        _owner = owner;
        _transitions = sourceObj._transitions;
    }
    /// <summary>
    /// Enter�����̋������s�B
    /// �X�e�[�g�}�V����,�ŏ��̃X�e�[�g�����蓖�Ă鎞�Ɏ��s����K�v�����������A<br/>
    /// Enter�𒼐ڌ��J�������Ȃ������̂Ŏd���Ȃ����̌`�ɂ����B
    /// ���������Ă��������玝���Ă��Ă��������B
    /// </summary>
    public void ExecuteEnter()
    {
        Enter();
    }
    /// <summary>
    /// �X�e�[�g�}�V�����疈�t���[���X�V����B
    /// </summary>
    public void Execute()
    {
        Update();
        OnTransition();
    }
    /// <summary>
    /// �������`�F�b�N���A�������������ꂽ��X�e�[�g��J�ڂ���B
    /// </summary>
    private void OnTransition()
    {
        // �S�Ă̑J�ڏ������`�F�b�N����
        for (int i = 0; i < _transitions.Length; i++)
        {
            // �X�e�[�g�}�V���̏�Ԃ��m�F���A�������������Ă�����J�ڂ���
            if (_owner.Conditions.HasFlag(_transitions[i].Conditions))
            {
                // ���X�e�[�g��Exit���������s
                _owner.CurrentState.Exit();
                // �X�e�[�g���X�V
                _owner.ChangeState(_transitions[i].NextState);
                // �V�X�e�[�g��Enter���������s
                _owner.CurrentState.Enter();
                // �X�e�[�g�}�V���̏�Ԃ����Z�b�g
                _owner.Conditions = Conditions.None;
                return;
            }
        }
    }

    protected abstract void Enter();
    protected abstract void Update();
    protected abstract void Exit();

    /// <summary>
    /// �����ƑJ�ڐ�̑g�ݍ��킹
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

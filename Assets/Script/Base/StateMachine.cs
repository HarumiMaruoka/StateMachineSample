using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
    protected IState CurrentState { get; private set; }

    public event Action<IState> OnStateChanged = default;

    // �ŏ��̃X�e�[�g��ݒ肷��B
    protected void Initialize(IState state)
    {
        CurrentState = state;
        state.Enter();

        // �X�e�[�g�ω����Ɏ��s����A�N�V�����B
        // �����ɍŏ��̃X�e�[�g��n���B
        OnStateChanged?.Invoke(state);
    }

    // �X�e�[�g�̑J�ڏ����B�����Ɂu���̃X�e�[�g�̎Q�Ɓv���󂯎��B
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();      // ���݃X�e�[�g�̏I�������B
        CurrentState = nextState; // ���݂̃X�e�[�g�̕ύX�����B
        nextState.Enter();        // �ύX���ꂽ�u�V�������݃X�e�[�g�v��Enter�����B

        // �X�e�[�g�ύX���̃A�N�V���������s����B
        // �����Ɂu�V�������݃X�e�[�g�v��n���B
        OnStateChanged?.Invoke(nextState);
    }
    protected abstract void StateInit();
}

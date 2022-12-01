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
        // ���݂̃X�e�[�g��\���ϐ�
        public IState CurrentState { get; private set; }

        // �e�X�e�[�g�̎Q�ƕϐ��i���ׂ�IState���p�����Ă���B�j
        public WalkState walkState;
        public JumpState jumpState;
        public IdleState idleState;

        // �X�e�[�g���ύX���ꂽ�Ƃ��Ɏ��s���郁�\�b�h
        public event Action<IState> stateChanged;

        // �R���X�g���N�^�B
        public StateMachine(PlayerController player)
        {
            // �X�e�[�g�̃C���X�^���X�𐶐����A�Q�Ƃ�ϐ��ɕۑ�����B
            this.walkState = new WalkState(player);
            this.jumpState = new JumpState(player);
            this.idleState = new IdleState(player);
        }

        // �ŏ��̃X�e�[�g��ݒ肷��B
        public void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();

            // �X�e�[�g�ω����Ɏ��s����A�N�V�����B
            // �����ɍŏ��̃X�e�[�g��n���B
            stateChanged?.Invoke(state);
        }

        // �X�e�[�g�̑J�ڏ����B�����Ɂu���̃X�e�[�g�̎Q�Ɓv���󂯎��B
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();      // ���݃X�e�[�g�̏I�������B
            CurrentState = nextState; // ���݂̃X�e�[�g�̕ύX�����B
            nextState.Enter();        // �ύX���ꂽ�u�V�������݃X�e�[�g�v��Enter�����B

            // �X�e�[�g�ύX���̃A�N�V���������s����B
            // �����Ɂu�V�������݃X�e�[�g�v��n���B
            stateChanged?.Invoke(nextState);
        }

        // ���݃X�e�[�g�̍X�V���������s
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}

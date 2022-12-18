using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // ��Ԃ�\���񋓌^
    public enum State
    {
        Idle,
        Move,
        Attack
    }

    // ���݂̏��
    public State currentState = State.Idle;

    // ��Ԃ�؂�ւ��邽�߂̊֐�
    public void ChangeState(State newState)
    {
        // ���݂̏�Ԃ��I������
        OnExitState(currentState);

        // ���݂̏�Ԃ��X�V����
        currentState = newState;

        // �V������Ԃ��J�n����
        OnEnterState(currentState);
    }

    // ��Ԃ��J�n�����Ƃ��ɌĂяo�����֐�
    public void OnEnterState(State state)
    {
        switch (state)
        {
            case State.Idle:
                // �ҋ@��Ԃ̏���
                break;
            case State.Move:
                // �ړ���Ԃ̏���
                break;
            case State.Attack:
                // �U����Ԃ̏���
                break;
        }
    }

    // ��Ԃ��I�������Ƃ��ɌĂяo�����֐�
    public void OnExitState(State state)
    {
        switch (state)
        {
            case State.Idle:
                // �ҋ@��Ԃ̏I������
                break;
            case State.Move:
                // �ړ���Ԃ̏I������
                break;
            case State.Attack:
                // �U����Ԃ̏I������
                break;
        }
    }

    // ���t���[���Ăяo�����֐�
    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                // �ҋ@��Ԃ̍X�V����
                break;
            case State.Move:
                // �ړ���Ԃ̍X�V����
                break;
            case State.Attack:
                // �U����Ԃ̍X�V����
                break;
        }
    }
}
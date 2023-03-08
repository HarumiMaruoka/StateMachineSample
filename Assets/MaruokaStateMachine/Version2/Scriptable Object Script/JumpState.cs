using UnityEngine;

[CreateAssetMenu]
public class JumpState : State
{
    protected override void Enter()
    {
        Debug.Log("じゃんぷ開始");
    }

    protected override void Exit()
    {
        //Debug.Log("じゃんぷおわり");
    }

    protected override void Update()
    {
        //Debug.Log("じゃんぷなう");
    }
}

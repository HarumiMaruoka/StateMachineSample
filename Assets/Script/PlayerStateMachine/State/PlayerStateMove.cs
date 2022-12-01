using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerStateBase
{
    private Rigidbody2D _rigidbody2D = null;
    private GroundedChecker _playerGrounded = null;
    public void Init(PlayerStateMachine stateMachine, Rigidbody2D rigidbody2D,
        GroundedChecker playerGrounded)
    {
        base.Init(stateMachine);
        _rigidbody2D = rigidbody2D;
        _playerGrounded = playerGrounded;
    }

    public override void Enter()
    {
        Move();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        Move();
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1f)
        {
            // ステートをIdleに遷移する
        }
        if (Input.GetButtonDown("Jump") && _playerGrounded.IsGrounded)
        {
            // ステートをJumpに遷移する
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), _rigidbody2D.velocity.y);
    }
}

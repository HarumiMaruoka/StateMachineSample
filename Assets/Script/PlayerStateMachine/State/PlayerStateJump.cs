using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateJump : PlayerStateBase
{
    [SerializeField]
    private float _jumpPower = 1f;

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
        _rigidbody2D.velocity = Vector2.up * _jumpPower;
    }

    public override void Exit()
    {
        // 何もしない
    }

    public override void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(h, _rigidbody2D.velocity.y);

        if (_playerGrounded.IsGrounded && _rigidbody2D.velocity.y < 0.1f)
        {
            if (Mathf.Abs(_rigidbody2D.velocity.x) < 0.1f)
            {
                // ステートをMoveに遷移する
            }
            else
            {
                // ステートをIdleに遷移する
            }
        }
    }
}

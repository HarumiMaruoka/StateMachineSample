using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundedChecker))]
public class PlayerStateMachine : StateMachine
{
    #region State
    [SerializeField]
    private PlayerStateIdle _stateIdle = default;
    [SerializeField]
    private PlayerStateMove _stateMove = default;
    [SerializeField]
    private PlayerStateJump _stateJump = default;

    private PlayerController _playerController = null;

    public PlayerStateIdle StateIdle => _stateIdle;
    public PlayerStateMove StateMove => _stateMove;
    public PlayerStateJump StateJump => _stateJump;
    public PlayerController PlayerController => _playerController;

    protected override void StateInit()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        var groundChecker = GetComponent<GroundedChecker>();
        _stateIdle.Init(this);
        _stateMove.Init(this);
        _stateJump.Init(this);
    }
    #endregion

    void Start()
    {
        Initialize(_stateIdle);
    }
}

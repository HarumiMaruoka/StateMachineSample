using System;
using System.Collections.Generic;
using UnityEngine;

public class MySelfStateMachine : MonoBehaviour
{
    [SerializeField]
    private State _initState = default;

    private PlayerController2D _playerController2D = default;

    public State CurrentState { get; set; } = null;
    public Conditions Conditions { get; set; } = Conditions.None;

    public PlayerController2D PlayerController2D => _playerController2D;

    private void Start()
    {
        _playerController2D = GetComponent<PlayerController2D>();
        CurrentState = _initState;
        _initState.Init(this);
    }
    private void Update()
    {
        CurrentState.Execute(this);
    }
}
[Flags, Serializable]
public enum Conditions
{
    None = 0,
    Everything = -1,
    Idle = 1,
    Move = 2,
    Midair = 4,
}
using System;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField]
    private Transition[] _transitions;

    private MySelfStateMachine _mySelfStateMachine = null;

    private bool _isInit = false;

    public void Execute(MySelfStateMachine mySelfStateMachine)
    {
        Update();
        OnTransition(mySelfStateMachine);
    }

    public void Init(MySelfStateMachine mySelfStateMachine)
    {
        if (_isInit)
        {
            return;
        }

        _isInit = true;
        _mySelfStateMachine = mySelfStateMachine;
    }

    private void OnTransition(MySelfStateMachine mySelfStateMachine)
    {
        for (int i = 0; i < _transitions.Length; i++)
        {
            if (_mySelfStateMachine.Conditions.HasFlag(_transitions[i].Conditions))
            {
                Exit();
                _mySelfStateMachine.CurrentState = _transitions[i].NextState;

                if (!_transitions[i].NextState._isInit)
                {
                    _transitions[i].NextState.Init(mySelfStateMachine);
                }
                _mySelfStateMachine.Conditions = Conditions.None;
                _mySelfStateMachine.CurrentState.Enter();
                return;
            }
        }
    }

    protected abstract void Enter();
    protected abstract void Update();
    protected abstract void Exit();


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

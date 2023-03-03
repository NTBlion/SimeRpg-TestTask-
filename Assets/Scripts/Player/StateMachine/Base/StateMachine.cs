using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(Animator))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    protected State _currentState;
    protected PlayerMove _playerMove;
    protected Animator _animator;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_playerMove, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_playerMove, _animator);
    }
}

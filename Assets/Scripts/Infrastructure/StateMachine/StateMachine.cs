using System;
using System.Collections.Generic;

public abstract class StateMachine {
    protected Dictionary<Type, State> _states;
    protected State _activeState;

    public void TranslateTo<TState>() where TState : State {
        _activeState?.Exit();
        _activeState = _states[typeof(TState)];
        _activeState?.Enter();
    }
}

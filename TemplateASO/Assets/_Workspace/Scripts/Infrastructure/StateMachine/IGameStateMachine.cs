using System;
using System.Collections.Generic;
using _Workspace.Scripts.Infrastructure.StateMachine.States;
using _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces;

namespace _Workspace.Scripts.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        Dictionary<Type, IExitableState> StatesMap { get; set; }
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>;
    }
}
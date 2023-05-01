using System;
using _Workspace.Scripts.Infrastructure.StateMachine.States;
using _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces;

namespace _Workspace.Scripts.Infrastructure.StateMachine.StateFactory
{
    public interface IStateFactory
    {
        IExitableState Create(IGameStateMachine machine, Type type);
    }
}
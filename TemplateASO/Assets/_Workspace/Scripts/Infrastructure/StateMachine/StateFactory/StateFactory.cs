using System;
using _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace _Workspace.Scripts.Infrastructure.StateMachine.StateFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
            => _container = container;

        public IExitableState Create(IGameStateMachine machine, Type type)
        {
            IExitableState state = _container.Instantiate(type, new[] { machine }) as IExitableState;
            machine.StatesMap.Add(type,state);
            return state;
        }
    }
}
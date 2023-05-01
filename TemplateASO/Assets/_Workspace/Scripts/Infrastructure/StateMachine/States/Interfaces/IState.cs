namespace _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
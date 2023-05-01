namespace _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces
{
    public interface IPayloadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}
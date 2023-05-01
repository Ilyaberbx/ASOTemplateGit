using _Workspace.Scripts.Infrastructure.Network;
using _Workspace.Scripts.Infrastructure.SceneLoad;
using _Workspace.Scripts.Infrastructure.StateMachine;
using _Workspace.Scripts.Infrastructure.StateMachine.StateFactory;
using _Workspace.Scripts.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace _Workspace.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private string _domain;

        private ISceneLoader _sceneLoader;
        private IGameStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IServerRequest _serverRequest;

        [Inject]
        public void Construct(IGameStateMachine stateMachine, IStateFactory stateFactory, ISceneLoader sceneLoader,IServerRequest serverRequest)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _sceneLoader = sceneLoader;
            _serverRequest = serverRequest;
        }

        private void Start()
        {
            InitCoroutineActors();

            _stateFactory.Create(_stateMachine, typeof(RequestConfigState));
            _stateFactory.Create(_stateMachine, typeof(LoadSavedData));
            
            _stateMachine.Enter<LoadSavedData, string>(_domain);
            DontDestroyOnLoad(this); // As Coroutine Runner!
        }

        private void InitCoroutineActors()
        {
            _sceneLoader.Init(this);
            _serverRequest.Init(this);
        }
    }
}
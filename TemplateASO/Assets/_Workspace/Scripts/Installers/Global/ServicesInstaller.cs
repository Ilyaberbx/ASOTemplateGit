using _Workspace.Scripts.Infrastructure.AppStaticData;
using _Workspace.Scripts.Infrastructure.Network;
using _Workspace.Scripts.Infrastructure.SaveLoad;
using _Workspace.Scripts.Infrastructure.SceneLoad;
using _Workspace.Scripts.Infrastructure.StateMachine;
using _Workspace.Scripts.Infrastructure.StateMachine.StateFactory;
using UnityEngine;
using Zenject;

namespace _Workspace.Scripts.Installers.Global
{
    [CreateAssetMenu(fileName = "ServiceInstaller", menuName = "Installers/ServiceInstaller")]
    public class ServicesInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindAppData();
            BindServerRequest();
            BindSaveLoader();
        }

        private void BindAppData() =>
            Container.BindInterfacesTo<AppDataService>()
                .AsSingle()
                .NonLazy();

        private void BindSaveLoader() =>
            Container.BindInterfacesTo<SaveLoader>()
                .AsSingle()
                .NonLazy();

        private void BindServerRequest() =>
            Container.BindInterfacesTo<ServerRequest>()
                .AsSingle()
                .NonLazy();


        private void BindSceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>()
                .AsSingle()
                .NonLazy();

        private void BindStateFactory() =>
            Container.BindInterfacesTo<StateFactory>()
                .AsSingle()
                .NonLazy();

        private void BindStateMachine() =>
            Container.BindInterfacesTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
    }
}
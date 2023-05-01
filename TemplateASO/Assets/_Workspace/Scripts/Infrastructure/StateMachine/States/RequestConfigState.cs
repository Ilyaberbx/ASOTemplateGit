using _Workspace.Scripts.Data.Config;
using _Workspace.Scripts.Extenstion;
using _Workspace.Scripts.Infrastructure.AppStaticData;
using _Workspace.Scripts.Infrastructure.Network;
using _Workspace.Scripts.Infrastructure.SaveLoad;
using _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces;
using _Workspace.Scripts.Tools;
using UnityEngine.Networking;

namespace _Workspace.Scripts.Infrastructure.StateMachine.States
{
    public class RequestConfigState : IPayloadedState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IServerRequest _requester;
        private readonly ISaveLoader _saveLoader;
        private readonly IAppDataService _appData;

        public RequestConfigState(IGameStateMachine stateMachine, IServerRequest requester
            , ISaveLoader saveLoader, IAppDataService appData)
        {
            _stateMachine = stateMachine;
            _requester = requester;
            _saveLoader = saveLoader;
            _appData = appData;
        }

        public void Enter(string domain)
            => _requester.GetRequest(domain, HandleRequestComplete);

        private void HandleRequestComplete(UnityWebRequest request)
        {
            if (request == null)
            {
                //OpenPlug();
            }
            else if (_appData.AppConfig != null)
            {
                if (IsError())
                    _appData.AppConfig = ConvertRequestCodeToAppConfig(request);
            }
            else
                _appData.AppConfig = ConvertRequestCodeToAppConfig(request);

            _saveLoader.SaveAppConfig(_appData.AppConfig);
        }

        public void Exit()
        { }


        private AppConfig ConvertRequestCodeToAppConfig(UnityWebRequest request)
            => Base64Convertor.ReturnFromBase64(request.downloadHandler.text).ToDeserialized<AppConfig>();

        private bool IsError()
            => _appData.AppConfig.error;
    }
}
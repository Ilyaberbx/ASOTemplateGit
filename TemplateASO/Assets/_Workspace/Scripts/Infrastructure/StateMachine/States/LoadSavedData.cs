using System.Globalization;
using _Workspace.Scripts.Data;
using _Workspace.Scripts.Infrastructure.AppStaticData;
using _Workspace.Scripts.Infrastructure.SaveLoad;
using _Workspace.Scripts.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine.Device;

namespace _Workspace.Scripts.Infrastructure.StateMachine.States
{
    public class LoadSavedData : IPayloadedState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IAppDataService _appData;
        private readonly ISaveLoader _saveLoader;

        public LoadSavedData(IGameStateMachine stateMachine, IAppDataService appData, ISaveLoader saveLoader)
        {
            _stateMachine = stateMachine;
            _appData = appData;
            _saveLoader = saveLoader;
        }

        public void Enter(string domain)
        {
            _appData.AppConfig = _saveLoader.LoadConfig();
            _appData.ClientData = ClientByDefault();
            _stateMachine.Enter<RequestConfigState, string>(domain);
        }

        public void Exit()
        { }

        private ClientData ClientByDefault()
        {
            ClientData newData = new ClientData();

            newData.client_id = SystemInfo.deviceUniqueIdentifier;
            newData.install_referrer = Application.installerName;
            newData.carrier_code = CultureInfo.CurrentCulture.Parent.ToString();
            newData.app_device_type = SystemInfo.deviceType.ToString();
            newData.app_locale = CultureInfo.CurrentCulture.Name;
            newData.app_device_name = SystemInfo.deviceName;
            newData.app_client_id = SystemInfo.deviceUniqueIdentifier;
            newData.package = Application.identifier;

            return newData;
        }
    }
}
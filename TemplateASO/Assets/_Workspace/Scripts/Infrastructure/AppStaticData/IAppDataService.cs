using _Workspace.Scripts.Data;
using _Workspace.Scripts.Data.Config;

namespace _Workspace.Scripts.Infrastructure.AppStaticData
{
    public interface IAppDataService
    {
        AppConfig AppConfig { get; set; }
        ClientData ClientData { get; set; }
    }
}
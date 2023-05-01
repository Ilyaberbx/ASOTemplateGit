using _Workspace.Scripts.Data;
using _Workspace.Scripts.Data.Config;

namespace _Workspace.Scripts.Infrastructure.AppStaticData
{
    public class AppDataService : IAppDataService
    {
        public AppConfig AppConfig { get; set; }
        public ClientData ClientData { get; set; }
    }
}
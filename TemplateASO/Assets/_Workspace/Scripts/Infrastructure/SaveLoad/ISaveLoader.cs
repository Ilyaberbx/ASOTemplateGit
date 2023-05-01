using _Workspace.Scripts.Data.Config;

namespace _Workspace.Scripts.Infrastructure.SaveLoad
{
    public interface ISaveLoader
    {
        void SaveAppConfig(AppConfig appConfig);
        AppConfig LoadConfig();
    }
}
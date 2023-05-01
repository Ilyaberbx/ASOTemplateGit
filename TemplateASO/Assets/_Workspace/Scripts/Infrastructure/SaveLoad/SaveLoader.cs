using _Workspace.Scripts.Data.Config;
using _Workspace.Scripts.Extenstion;
using UnityEngine;

namespace _Workspace.Scripts.Infrastructure.SaveLoad
{
    public class SaveLoader : ISaveLoader
    {
        private const string AppConfigKey = "AppConfig";

        public void SaveAppConfig(AppConfig appConfig)
            => PlayerPrefs.SetString(AppConfigKey, appConfig.ToJson());

        public AppConfig LoadConfig()
            => PlayerPrefs.GetString(AppConfigKey)?.ToDeserialized<AppConfig>();
    }
}
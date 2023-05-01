using System;

namespace _Workspace.Scripts.Data.Config
{
    [Serializable]
    public class AppConfig
    {
        public bool error;
        public string name;
        public string webview;
        public Appsflyer appsflyer;
        public Onesignal onesignal;
        public FaceBook facebook;
    }
}
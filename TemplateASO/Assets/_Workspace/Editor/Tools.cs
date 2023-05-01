using UnityEditor;
using UnityEngine;

namespace _Workspace.Editor
{
    public static class Tools 
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
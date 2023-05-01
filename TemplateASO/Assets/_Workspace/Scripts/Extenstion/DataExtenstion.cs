using UnityEngine;

namespace _Workspace.Scripts.Extenstion
{
    public static class DataExtenstion
    {
        public static T ToDeserialized<T>(this string json) 
            => JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj)
            => JsonUtility.ToJson(obj);
    }
}
using System;
using UnityEngine.Networking;

namespace _Workspace.Scripts.Infrastructure.Network
{
    public interface IServerRequest
    {
        void Init(ICoroutineRunner coroutineRunner);
        void GetRequest(string url, Action<UnityWebRequest> onCompleted);
    }
}
using System;
using System.Collections;
using _Workspace.Scripts.Data;
using _Workspace.Scripts.Infrastructure.AppStaticData;
using UnityEngine;
using UnityEngine.Networking;

namespace _Workspace.Scripts.Infrastructure.Network
{
    public class ServerRequest : IServerRequest
    {
        private readonly IAppDataService _appData;
        private const string RequestHeader = "X-Requested-With";
        private ICoroutineRunner _coroutineRunner;
        private ClientData _clientData;

        public ServerRequest(IAppDataService appData) 
            => _appData = appData;

        public void Init(ICoroutineRunner coroutineRunner)
            => _coroutineRunner = coroutineRunner;

        public void GetRequest(string url, Action<UnityWebRequest> onCompleted = null)
            => _coroutineRunner.StartCoroutine(GetRequestRoutine(url, onCompleted));

        private IEnumerator GetRequestRoutine(string url, Action<UnityWebRequest> onCompleted)
        {
            UnityWebRequest request = new UnityWebRequest(url, "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            Debug.Log(_appData.ClientData.package);
            request.SetRequestHeader(RequestHeader, _appData.ClientData.package);
            
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                request.Dispose();
                request = null;
            }

            onCompleted?.Invoke(request);
            request?.Dispose();
        }
    }
}
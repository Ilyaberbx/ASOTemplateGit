using System;

namespace _Workspace.Scripts.Infrastructure.SceneLoad
{
    public interface ISceneLoader
    {
        void Init(ICoroutineRunner coroutineRunner);
        void Load(string name, Action onLoaded = null);
    }
}
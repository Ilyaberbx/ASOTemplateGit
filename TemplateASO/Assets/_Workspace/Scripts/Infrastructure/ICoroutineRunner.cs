using System.Collections;
using UnityEngine;

namespace _Workspace.Scripts.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}
using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Util
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
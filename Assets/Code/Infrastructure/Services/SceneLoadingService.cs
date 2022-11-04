using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Services
{
    public class SceneLoadingService
    {
        public AsyncOperation Load(string name)
        {
            return SceneManager.LoadSceneAsync(name);
        }
    }
}
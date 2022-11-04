using Code.Infrastructure.Services;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
    public class LoadLevelState : IGameState
    {
        private readonly SceneLoadingService sceneLoaderService;

        public LoadLevelState(SceneLoadingService sceneLoader)
        {
            sceneLoaderService = sceneLoader;
        }
        
        public void Enter()
        {
            sceneLoaderService.Load("Main");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
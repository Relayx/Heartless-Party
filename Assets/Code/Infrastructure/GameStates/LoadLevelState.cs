using UnityEngine;

namespace Code.Infrastructure.GameStates
{
    public class LoadLevelState : IGameState
    {
        public void Enter()
        {
            Debug.Log("LoadLevelState");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
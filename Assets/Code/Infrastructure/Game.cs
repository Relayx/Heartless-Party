using Code.Infrastructure.GameStates;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        private GameStateMachine stateMachine;

        public Game(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            stateMachine.Enter<LoadLevelState>();
        }
    }
}
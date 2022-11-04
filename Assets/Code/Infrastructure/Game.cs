using Code.Infrastructure.GameStates;

namespace Code.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine stateMachine;

        public Game()
        {
            this.stateMachine = new GameStateMachine();
            stateMachine.Enter<LoadLevelState>();
        }
    }
}
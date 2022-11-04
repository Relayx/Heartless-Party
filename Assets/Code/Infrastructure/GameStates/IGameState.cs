namespace Code.Infrastructure.GameStates
{
    public interface IGameState
    {
        public void Enter();
        public void Exit();
    }
}
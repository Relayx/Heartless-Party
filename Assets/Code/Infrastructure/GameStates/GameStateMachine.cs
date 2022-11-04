using System;
using System.Collections.Generic;
using Code.Infrastructure.Services;

namespace Code.Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> states;
        private IGameState currentState;

        public GameStateMachine()
        {
            states = new Dictionary<Type, IGameState>()
            {
                [typeof(LoadLevelState)] = new LoadLevelState(new SceneLoadingService())
            };
        }

        public void Enter<TState>() where TState : IGameState
        {
            currentState?.Exit();
            var newState = states[typeof(TState)];
            newState.Enter();
        }
    }
}
using System;
using System.Collections.Generic;
using Code.Infrastructure.GameStates;

namespace Code.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> states;
        private IGameState currentState;

        public GameStateMachine()
        {
            states = new Dictionary<Type, IGameState>()
            {
                [typeof(LoadLevelState)] = new LoadLevelState()
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
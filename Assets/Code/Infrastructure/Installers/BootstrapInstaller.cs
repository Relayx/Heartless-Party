using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGame();
        }

        private void InstallGame()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<Game>()
                .AsSingle()
                .NonLazy();
        }
    }
}
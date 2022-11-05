using Code.Infrastructure.Services;
using Code.Infrastructure.Util;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            InstallSceneLoadingService();
            InstallEventService();
            
            InstallCoroutineRunner();
            InstallGame();
        }

        private void InstallEventService()
        {
            Container
                .Bind<EventsService>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallSceneLoadingService()
        {
            Container
                .Bind<SceneLoadingService>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallCoroutineRunner()
        { 
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();
        }

        private void InstallGame()
        {
            Container
                .Bind<Game>()
                .AsSingle()
                .NonLazy();
        }
    }
}
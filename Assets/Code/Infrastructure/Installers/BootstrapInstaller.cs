using Code.Infrastructure.Services;
using Code.Infrastructure.Util;
using Code.Level;
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
            
            InstallLevelGenerator();
            InstallLevelService();
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

        private void InstallLevelGenerator()
        {
            Container
                .Bind<LevelGenerator>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InstallLevelService()
        {
            Container
                .Bind<LevelService>()
                .AsSingle()
                .NonLazy();
        }
    }
}
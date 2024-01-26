using Zenject;

namespace Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplaySettingsConfig>()
                .FromResource("GameplaySettingsConfig")
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<GameController>()
                .AsSingle()
                .NonLazy();
            
            UIInstaller.Install(Container);
            AnimationInstaller.Install(Container);
            CardInstaller.Install(Container);
            CardModuleInstaller.Install(Container);
        }
    }
}
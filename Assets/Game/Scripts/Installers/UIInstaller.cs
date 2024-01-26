using Game.UI;
using Game.UI.Abstract;
using Zenject;

namespace Game.Installers
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UIRoot>()
                .FromComponentInNewPrefabResource("UIRoot")
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<WindowsManager>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<UIHUDWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}
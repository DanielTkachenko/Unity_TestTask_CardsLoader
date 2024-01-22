using Game.CardModule;
using Game.CardModule.Abstract;
using Game.CardModule.Handlers;
using Zenject;

namespace Game.Installers
{
    public class CardModuleInstaller : Installer<CardModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPictureLoadHandler>()
                .To<PictureLoadHandler>()
                .AsSingle()
                .NonLazy();
            
            /*Container.Bind<CardsFlipHandler>()
                .AsSingle()
                .NonLazy();*/
            
            Container.Bind<CardModuleConfig>()
                .FromResource("CardModuleConfig")
                .AsSingle()
                .NonLazy();

            Container.Bind<IModuleController>()
                .To<CardModuleController>()
                .AsSingle()
                .NonLazy();

            Container.BindFactory<CardModuleView, CardModuleView.Factory>()
                .FromComponentInNewPrefabResource("CardModuleView");
        }
    }
}
using Game.Card;
using Zenject;

namespace Game.Installers
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CardConfig>()
                .FromResource("CardConfig")
                .AsSingle()
                .NonLazy();

            Container.Bind<CardController>()
                .AsSingle()
                .NonLazy();

            Container.BindMemoryPool<CardView, CardView.Pool>()
                .WithInitialSize(4)
                .FromComponentInNewPrefabResource("CardView")
                .UnderTransformGroup("Cards");
        }
    }
}
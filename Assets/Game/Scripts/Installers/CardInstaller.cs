using Game.Card;
using Zenject;

namespace Game.Installers
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CardController>()
                .AsSingle()
                .NonLazy();

            Container.BindMemoryPool<CardView, CardView.Pool>()
                .FromComponentInNewPrefabResource("CardView")
                .UnderTransformGroup("Cards");
        }
    }
}
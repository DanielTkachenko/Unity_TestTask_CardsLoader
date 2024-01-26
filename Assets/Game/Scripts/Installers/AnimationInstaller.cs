using Game.Card;
using Game.Card.Abstract;
using Game.Card.Handlers;
using Zenject;

namespace Game.Installers
{
    public class AnimationInstaller : Installer<AnimationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICardAnimationHandler>()
                .To<CardAnimationHandler>()
                .AsSingle()
                .NonLazy();
        }
    }
}
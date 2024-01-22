using Game.Card;
using Game.Card.Abstract;
using Zenject;

namespace Game.Installers
{
    public class AnimationInstaller : Installer<AnimationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AnimationConfig>()
                .FromResource("CardAnimationConfig")
                .AsSingle()
                .NonLazy();

            Container.Bind<ICardAnimationHandler>()
                .To<CardAnimationHandler>()
                .AsSingle()
                .NonLazy();
        }
    }
}
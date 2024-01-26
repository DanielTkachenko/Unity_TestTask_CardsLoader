using System;
using Cysharp.Threading.Tasks;

namespace Game.Card.Abstract
{
    public interface ICardAnimationHandler
    {
        Action<CardView> OnFlipAnimationComplete { get; }
        UniTask PlayFlipAnimation(CardView cardView);
    }
}
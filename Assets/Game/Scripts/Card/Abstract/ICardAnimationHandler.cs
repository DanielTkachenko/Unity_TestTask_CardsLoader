using System;
using Cysharp.Threading.Tasks;

namespace Game.Card.Abstract
{
    public interface ICardAnimationHandler
    {
        UniTask PlayFlipAnimation(CardView cardView);
    }
}
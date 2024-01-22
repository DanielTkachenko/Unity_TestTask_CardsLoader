using System.Collections.Generic;

namespace Game.CardModule.Abstract
{
    public interface ICardsFlipHandler
    {
        void Flip(IEnumerable<CardView> list);
    }
}
using System.Collections.Generic;
using Game.Card.Abstract;
using Game.CardModule.Abstract;

namespace Game.CardModule.Handlers
{
    public abstract class CardsFlipHandler : ICardsFlipHandler
    {
        protected readonly IPictureLoadHandler _pictureLoadHandler;
        protected readonly ICardAnimationHandler _cardAnimationHandler;

        public CardsFlipHandler(
            IPictureLoadHandler pictureLoadHandler,
            ICardAnimationHandler cardAnimationHandler)
        {
            _pictureLoadHandler = pictureLoadHandler;
            _cardAnimationHandler = cardAnimationHandler;
        }
        

        public abstract void Flip(IEnumerable<CardView> list);
    }
}
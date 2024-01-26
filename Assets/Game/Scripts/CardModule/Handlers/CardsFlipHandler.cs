using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;

namespace Game.CardModule.Handlers
{
    public abstract class CardsFlipHandler : ICardsFlipHandler
    {
        public Action OnCardsFlipFinished { get; }
        
        protected readonly IPictureLoadHandler _pictureLoadHandler;
        protected readonly ICardAnimationHandler _cardAnimationHandler;

        public CardsFlipHandler(
            IPictureLoadHandler pictureLoadHandler,
            ICardAnimationHandler cardAnimationHandler)
        {
            _pictureLoadHandler = pictureLoadHandler;
            _cardAnimationHandler = cardAnimationHandler;
        }
        
        public abstract UniTaskVoid Flip(IEnumerable<CardView> list, string url);
    }
}
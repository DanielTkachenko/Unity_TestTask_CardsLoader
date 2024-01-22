using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;
using UnityEngine;

namespace Game.CardModule.Handlers
{
    public class CardsFlipHandlerAllTogether : CardsFlipHandler
    {
        public CardsFlipHandlerAllTogether(
            IPictureLoadHandler pictureLoadHandler, 
            ICardAnimationHandler cardAnimationHandler) 
            : base(pictureLoadHandler, cardAnimationHandler)
        {
        }

        public override void Flip(IEnumerable<CardView> list)
        {
            var task = FlipAsync(list);
        }
        
        private async UniTask FlipAsync(IEnumerable<CardView> list)
        {
            //need to define
        }
    }
}
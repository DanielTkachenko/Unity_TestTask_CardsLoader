using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;
using UnityEngine;

namespace Game.CardModule.Handlers
{
    public class CardsFlipHandlerOneByOne : CardsFlipHandler
    {
        public CardsFlipHandlerOneByOne(
            IPictureLoadHandler pictureLoadHandler, 
            ICardAnimationHandler cardAnimationHandler) 
            : base(pictureLoadHandler, cardAnimationHandler)
        {
        }

        public override async UniTaskVoid Flip(IEnumerable<CardView> list)
        {
            foreach (var item in list)
            {
                var task = LoadAndFlipOneCard(item);
                await UniTask.WhenAll(task);
            }
            
            OnCardsFlipFinished?.Invoke();
        }
        
        private async UniTask LoadAndFlipOneCard(CardView view)
        {
            var tex2d = await _pictureLoadHandler.DownloadPictureAsync();

            if (tex2d != null)
            {
                view.IconSpriteRenderer.sprite = 
                    Sprite.Create(tex2d, new Rect(0, 0, 20, 20), Vector2.zero);
            }
            
            await _cardAnimationHandler.PlayFlipAnimation(view);
        }
    }
}
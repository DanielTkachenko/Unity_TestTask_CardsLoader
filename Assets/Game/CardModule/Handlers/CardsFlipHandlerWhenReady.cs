using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;
using UnityEngine;

namespace Game.CardModule.Handlers
{
    public class CardsFlipHandlerWhenReady : CardsFlipHandler
    {
        public CardsFlipHandlerWhenReady(
            IPictureLoadHandler pictureLoadHandler, 
            ICardAnimationHandler cardAnimationHandler) 
            : base(pictureLoadHandler, cardAnimationHandler)
        {
        }

        public override void Flip(IEnumerable<CardView> list)
        {
            foreach (var item in list)
            {
                var task = LoadAndFlipOneCard(item);
            }
        }
        
        private async UniTask LoadAndFlipOneCard(CardView view)
        {
            var tex2d = await _pictureLoadHandler.DownloadPictureAsync();

            if (tex2d != null)
            {
                view.IconSpriteRenderer.sprite = 
                    Sprite.Create(tex2d, new Rect(0, 0, 20, 20), Vector2.zero);
            }
            
            _cardAnimationHandler.PlayFlipAnimation(view);
        }
    }
}
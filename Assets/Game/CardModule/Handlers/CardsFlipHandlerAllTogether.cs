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
            foreach (var item in list)
            {
                var tex2d = await _pictureLoadHandler.DownloadPictureAsync();

                if (tex2d != null)
                {
                    item.IconSpriteRenderer.sprite = 
                        Sprite.Create(tex2d, new Rect(0, 0, 20, 20), Vector2.zero);
                }
            }

            foreach (var item in list)
            {
                _cardAnimationHandler.PlayFlipAnimation(item);
            }
        }
    }
}
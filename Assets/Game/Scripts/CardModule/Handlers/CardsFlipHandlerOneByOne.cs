﻿using System.Collections.Generic;
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

        public override async UniTask Flip(IEnumerable<CardView> list, string url)
        {
            await base.Flip(list, url);
            foreach (var item in list)
            {
                var task = LoadAndFlipOneCard(item, url);
                await UniTask.WhenAll(task);
            }
            
            OnCardsFlipFinished?.Invoke();
        }
        
        private async UniTask LoadAndFlipOneCard(CardView view, string url)
        {
            var tex2d = await PictureLoadHandler.DownloadPictureAsync(url);

            if (tex2d != null)
            {
                view.IconSpriteRenderer.sprite = 
                    Sprite.Create(tex2d, new Rect(0, 0, 20, 20), Vector2.zero);
            }
            
            await CardAnimationHandler.PlayFlipAnimation(view);
        }
    }
}
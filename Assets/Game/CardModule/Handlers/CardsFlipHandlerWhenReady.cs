﻿using System.Collections.Generic;
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

        public override async UniTaskVoid Flip(IEnumerable<CardView> list)
        {
            List<UniTask> tasks = new List<UniTask>();
            
            foreach (var item in list)
            {
                var task = LoadAndFlipOneCard(item);
                tasks.Add(task);
            }

            await UniTask.WhenAll(tasks);
            
            tasks.Clear();
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
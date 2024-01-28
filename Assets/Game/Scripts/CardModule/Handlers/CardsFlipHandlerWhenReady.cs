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

        public override async UniTask Flip(IEnumerable<CardView> list, string url)
        {
            await base.Flip(list, url);
            List<UniTask> tasks = new List<UniTask>();
            
            foreach (var item in list)
            {
                var task = LoadAndFlipOneCard(item, url);
                tasks.Add(task);
            }

            await UniTask.WhenAll(tasks);
            
            tasks.Clear();
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
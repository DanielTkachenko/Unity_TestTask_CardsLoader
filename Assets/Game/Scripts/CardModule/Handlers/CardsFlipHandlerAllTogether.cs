using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;
using Unity.VisualScripting;
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

        public override async UniTaskVoid Flip(IEnumerable<CardView> list, string url)
        {
            await LoadPicturesForCollection(list, url);
            await PlayAnimationForCollection(list);
            OnCardsFlipFinished?.Invoke();
        }

        private async UniTask LoadPicturesForCollection(IEnumerable<CardView> list, string url)
        {
            List<UniTask> tasks = new List<UniTask>();
            foreach (var view in list)
            {
                var task = LoadOneCard(view, url);
                tasks.Add(task);
            }

            await UniTask.WhenAll(tasks);
            tasks.Clear();
        }

        private async UniTask PlayAnimationForCollection(IEnumerable<CardView> list)
        {
            List<UniTask> tasks = new List<UniTask>();
            foreach (var view in list)
            {
                var task = _cardAnimationHandler.PlayFlipAnimation(view);
                tasks.Add(task);
            }

            await UniTask.WhenAll(tasks);
            tasks.Clear();
        }
        
        private async UniTask LoadOneCard(CardView view, string url)
        {
            var tex2d = await _pictureLoadHandler.DownloadPictureAsync(url);

            if (tex2d != null)
            {
                view.IconSpriteRenderer.sprite = 
                    Sprite.Create(tex2d, new Rect(0, 0, 20, 20), Vector2.zero);
            }
        }
    }
}
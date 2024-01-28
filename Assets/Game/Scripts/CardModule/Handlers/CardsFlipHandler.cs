using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Card.Abstract;
using Game.CardModule.Abstract;

namespace Game.CardModule.Handlers
{
    public abstract class CardsFlipHandler : ICardsFlipHandler
    {
        public Action OnCardsFlipFinished { get; set; }
        
        protected CancellationTokenSource CancellationToken { get; } = new CancellationTokenSource();
        protected readonly IPictureLoadHandler PictureLoadHandler;
        protected readonly ICardAnimationHandler CardAnimationHandler;

        public CardsFlipHandler(
            IPictureLoadHandler pictureLoadHandler,
            ICardAnimationHandler cardAnimationHandler)
        {
            PictureLoadHandler = pictureLoadHandler;
            CardAnimationHandler = cardAnimationHandler;
        }

        public void Cancel()
        {
            CancellationToken.Cancel();
        }

        public virtual async UniTask Flip(IEnumerable<CardView> list, string url)
        {
            await FlipBack(list);
            //await UniTask.WaitForSeconds(1);
        }

        private async UniTask FlipBack(IEnumerable<CardView> list)
        {
            List<UniTask> tasks = new List<UniTask>();
            foreach (var view in list)
            {
                if (view.IsOpened)
                {
                    var task = CardAnimationHandler.PlayFlipAnimation(view);
                    tasks.Add(task);
                }
            }

            await UniTask.WhenAll(tasks);
            tasks.Clear();
        }
    }
}
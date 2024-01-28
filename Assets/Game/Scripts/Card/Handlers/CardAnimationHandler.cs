using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Card.Abstract;
using UnityEngine;

namespace Game.Card.Handlers
{
    public class CardAnimationHandler : ICardAnimationHandler
    {
        public CancellationTokenSource _cancellationToken { get; } = new CancellationTokenSource();

        private readonly float _flipAnimationDuration;

        public CardAnimationHandler(GameplaySettingsConfig gameplaySettings)
        {
            _flipAnimationDuration = gameplaySettings.CardAnimationConfig.FlipAnimationDuration;
        }

        public async UniTask PlayFlipAnimation(CardView cardView)
        {
            var seq = DOTween.Sequence()
                .Append(cardView.transform.DORotate(new Vector3(90, 0, 0), _flipAnimationDuration / 2)
                    .OnComplete(() => cardView.SetFrontSideActive(!cardView.IsOpened)))
                .Append(cardView.transform.DORotate(new Vector3(0, 0, 0), _flipAnimationDuration / 2))
                .SetLink(cardView.gameObject)
                .WithCancellation(_cancellationToken.Token);

            await UniTask.WhenAll(seq);
        }
    }
}
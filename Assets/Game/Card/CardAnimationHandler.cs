using DG.Tweening;
using Game.Card.Abstract;
using UnityEngine;

namespace Game.Card
{
    public class CardAnimationHandler : ICardAnimationHandler
    {
        private readonly float _flipAnimationDuration;

        public CardAnimationHandler(AnimationConfig cardAnimationConfig)
        {
            _flipAnimationDuration = cardAnimationConfig.FlipAnimationDuration;
        }
        public void PlayFlipAnimation(CardView cardView)
        {
            DOTween.Sequence()
                .Append(cardView.transform.DORotate(new Vector3(90, 0, 0), _flipAnimationDuration / 2)
                    .OnComplete(() => cardView.SetFrontSideActive(!cardView.IsOpened)))
                .Append(cardView.transform.DORotate(new Vector3(0, 0, 0), _flipAnimationDuration / 2))
                .SetLink(cardView.gameObject);
        }
    }
}
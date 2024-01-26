using System.Collections.Generic;
using Game.Card.Abstract;
using UnityEngine;

namespace Game.Card
{
    public class CardController
    {
        public IReadOnlyList<CardView> Views => _cardViews;
        
        private readonly CardModel _cardModel;
        private readonly CardView.Pool _cardViewPool;
        private readonly ICardAnimationHandler _cardAnimationHandler;
        
        private List<CardView> _cardViews;
        
        public CardController(
            GameplaySettingsConfig gameplaySettings,
            CardView.Pool cardViewPool,
            ICardAnimationHandler cardAnimationHandler)
        {
            _cardModel = gameplaySettings.CardConfig;
            _cardViewPool = cardViewPool;
            _cardAnimationHandler = cardAnimationHandler;
            _cardViews = new List<CardView>();
        }

        public CardView SpawnView(Vector3 position)
        {
            var newCardView = _cardViewPool.Spawn(_cardModel.Scale, position);
            _cardViews.Add(newCardView);
            
            return newCardView;
        }

        public void DeleteAll()
        {
            foreach (var view in _cardViews)
            {
                _cardViewPool.Despawn(view);
            }
            
            _cardViews.Clear();
        }
    }
}
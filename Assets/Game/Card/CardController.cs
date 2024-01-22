using System.Collections.Generic;
using Game.Card.Abstract;
using UnityEngine;

namespace Game.Card
{
    public class CardController
    {
        public IReadOnlyList<CardView> Views => _cardViews;
        
        private readonly CardConfig _cardConfig;
        private readonly CardView.Pool _cardViewPool;
        private readonly ICardAnimationHandler _cardAnimationHandler;
        
        private List<CardView> _cardViews;
        
        public CardController(
            CardConfig cardConfig,
            CardView.Pool cardViewPool,
            ICardAnimationHandler cardAnimationHandler)
        {
            _cardConfig = cardConfig;
            _cardViewPool = cardViewPool;
            _cardAnimationHandler = cardAnimationHandler;
            _cardViews = new List<CardView>();
        }

        public CardView SpawnView(Vector3 position)
        {
            var model = _cardConfig.Model;
            var newCardView = _cardViewPool.Spawn(model.Scale, position);
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
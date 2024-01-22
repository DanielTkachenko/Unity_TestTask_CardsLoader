using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Card;
using Game.Card.Abstract;
using Game.CardModule.Abstract;
using Game.CardModule.Handlers;
using Game.UI;
using Game.UI.Abstract;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.CardModule
{
    public enum FlipType
    {
        AllTogether,
        OneByOne,
        WhenReady
    }
    public class CardModuleController : IModuleController
    {
        private readonly CardModuleConfig _cardModuleConfig;
        private readonly CardModuleView.Factory _cardModuleFactory;
        private readonly CardController _cardController;
        private readonly CardsFlipHandler _cardsFlipHandler;

        private CardModuleView _view;
        private UIHUDWindow _uihudWindow;
        private IReadOnlyList<CardView> _cardViews;
        private List<ICardsFlipHandler> flipHandlersList;
        private int _cardsNumber;

        public CardModuleController(
            CardModuleConfig cardModuleConfig,
            CardModuleView.Factory cardModuleFactory,
            CardController cardController,
            IPictureLoadHandler pictureLoadHandler,
            ICardAnimationHandler cardAnimationHandler,
            IWindowsManager windowsManager
            )
        {
            _cardModuleConfig = cardModuleConfig;
            _cardModuleFactory = cardModuleFactory;
            _cardController = cardController;
            
            _view = null;
            _cardViews = cardController.Views;
            _cardsNumber = _cardModuleConfig.CardsNumber;
            _uihudWindow = windowsManager.Get<UIHUDWindow>();
            _uihudWindow.OnFlipButtonClickEvent += OnFlipButtonClickEvent;
            _uihudWindow.OnCancelButtonClickEvent += OnCancelButtonClickEvent;

            flipHandlersList = new List<ICardsFlipHandler>()
            {
                new CardsFlipHandlerOneByOne(pictureLoadHandler, cardAnimationHandler),
                new CardsFlipHandlerAllTogether(pictureLoadHandler, cardAnimationHandler),
                new CardsFlipHandlerWhenReady(pictureLoadHandler, cardAnimationHandler)
            };
        }

        private void OnCancelButtonClickEvent()
        {
            
        }

        private void OnFlipButtonClickEvent()
        {
            //rewrite architecture
            flipHandlersList[_uihudWindow.FlipTypesDropdownValue].Flip(_cardViews);
        }

        public void Init()
        {
            _view = _cardModuleFactory.Create();
            SpawnCards();
        }

        private void SpawnCards()
        {
            if (_view != null)
            {
                Vector3 leftSpawnPoint = _view.LeftSpawnPoint.position;
                Vector3 rightSpawnPoint = _view.RightSpawnPoint.position;
                float delta = (rightSpawnPoint.x - leftSpawnPoint.x) / (_cardsNumber - 1);
                for (int i = 0; i < _cardsNumber; i++)
                {
                    Vector2 spawnPosition = new Vector2(leftSpawnPoint.x + i * delta, leftSpawnPoint.y);
                    _cardController.SpawnView(spawnPosition);
                }
            }
        }
    }
}
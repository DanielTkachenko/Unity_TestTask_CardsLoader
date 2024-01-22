using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.CardModule;
using Game.CardModule.Abstract;
using Game.UI;
using Game.UI.Abstract;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : IInitializable, ITickable
    {
        private readonly IModuleController _currentModuleController;
        private readonly IWindowsManager _windowsManager;

        public GameController(
            IModuleController currentModuleController,
            IWindowsManager windowsManager)
        {
            _currentModuleController = currentModuleController;
            _windowsManager = windowsManager;
        }
        public void Initialize()
        {
            _currentModuleController.Init();
            _windowsManager.Show<UIHUDWindow>();
        }

        public async void Tick()
        {
            
        }
    }
}
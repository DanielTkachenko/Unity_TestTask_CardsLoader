using System;
using System.Collections.Generic;
using Game.UI.Abstract;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.UI
{
    public class WindowsManager : IWindowsManager
    {
        private readonly UIRoot _uiRoot;
        private readonly Dictionary<Type,UIWindow> _viewStorage = new Dictionary<Type,UIWindow>();
        
        private const string UISource = "";

        public WindowsManager(UIRoot uiRoot)
        {
            _uiRoot = uiRoot;
            Init();
        }

        public void Init()
        {
            var windows = Resources.LoadAll(UISource, typeof(UIWindow));

            foreach (var window in windows)
            {
                var windowType = window.GetType();

                UIWindow view = null;
                if (_uiRoot.DeactiveContainer != null)
                {
                    view = Object.Instantiate(window, _uiRoot.DeactiveContainer) as UIWindow;
                }
                else
                {
                    view = Object.Instantiate(window) as UIWindow;
                }

                _viewStorage.Add(windowType, view);
            }
        }

        public T Show<T>() where T : UIWindow
        {
            var window = Get<T>();
            if (window != null)
            {
                window.transform.SetParent(_uiRoot.ActiveContainer, false);
                window.Show();
                return window;
            }

            return null;
        }

        public void Hide<T>() where T : UIWindow
        {
            var window = Get<T>();
            if (window != null)
            {
                window.transform.SetParent(_uiRoot.DeactiveContainer, false);
                window.Hide();
            }
        }

        public T Get<T>() where T : UIWindow
        {
            var type = typeof(T);
            if (_viewStorage.ContainsKey(type))
            {
                return _viewStorage[type] as T;
            }

            return null;
        }
    }
}
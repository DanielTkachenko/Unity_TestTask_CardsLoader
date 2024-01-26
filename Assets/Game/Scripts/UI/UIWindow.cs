using System;
using Game.UI.Abstract;
using UnityEngine;

namespace Game.UI
{
    public abstract class UIWindow : MonoBehaviour, IUIWindow
    {
        [HideInInspector] public Action OnShowEvent;        
        [HideInInspector] public Action OnHideEvent;

        public virtual void Show()
        {
            OnShowEvent?.Invoke();
        }

        public virtual void Hide()
        {
            OnHideEvent?.Invoke();
        }
    }
}
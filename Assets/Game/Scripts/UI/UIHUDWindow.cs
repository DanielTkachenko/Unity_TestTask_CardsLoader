using System;
using Cysharp.Threading.Tasks;
using Game.CardModule;
using Game.UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIHUDWindow : UIWindow
    {
        public Action OnFlipButtonClickEvent;
        public Action OnCancelButtonClickEvent;
        
        public int FlipTypesDropdownValue => flipTypesDropdown.value;
        public Button FlipButton => flipButton;
        public Button CancelButton => cancelButton;
        
        [SerializeField] private Dropdown flipTypesDropdown;
        [SerializeField] private Button flipButton;
        [SerializeField] private Button cancelButton;
        
        public override void Show()
        {
            flipButton.onClick.AddListener(OnFlipButtonClick);
            cancelButton.onClick.AddListener(OnCancelButtonClick);
            base.Show();
        }
        
        public override void Hide()
        {
            flipButton.onClick.RemoveListener(OnFlipButtonClick);
            cancelButton.onClick.RemoveListener(OnCancelButtonClick);
            base.Hide();
        }

        private void OnFlipButtonClick()
        {
            OnFlipButtonClickEvent?.Invoke();
        }
        
        private void OnCancelButtonClick()
        {
            OnCancelButtonClickEvent?.Invoke();
        }
    }
}
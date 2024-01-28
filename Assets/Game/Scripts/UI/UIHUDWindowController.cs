using Game.UI.Abstract;

namespace Game.UI
{
    public class UIHUDWindowController
    {
        private UIHUDWindow _hudWindow;
        
        public UIHUDWindowController(IWindowsManager windowsManager)
        {
            _hudWindow = windowsManager.Get<UIHUDWindow>();
        }

        public void SetButtonsActive(bool flipButtonActive, bool cancelButtonActive)
        {
            _hudWindow.FlipButton.interactable = flipButtonActive;
            _hudWindow.CancelButton.interactable = cancelButtonActive;
        }
    }
}
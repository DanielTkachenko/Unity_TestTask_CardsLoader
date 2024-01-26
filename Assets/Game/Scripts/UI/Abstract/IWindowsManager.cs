namespace Game.UI.Abstract
{
    public interface IWindowsManager
    {
        void Init();
        T Show<T>() where T : UIWindow;
        void Hide<T>() where T : UIWindow;
        T Get<T>() where T : UIWindow;
    }
}
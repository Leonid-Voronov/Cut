using UI.MetagameUI.Windows;

namespace UI.MetagameUI
{
    public interface IWindowHolder
    {
        void ChangeWindow(IWindow newWindow);
        void CloseWindow();
    }
}
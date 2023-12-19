using UI.MetagameUI;
using UI.MetagameUI.Windows;

namespace UI
{
    public class MetagameWindowHolder : IWindowHolder
    {
        private IWindow _currentWindow = null;

        public void ChangeWindow(IWindow newWindow)
        {
            if (_currentWindow != null)
                _currentWindow.GameObject.SetActive(false);

            _currentWindow = newWindow;
            _currentWindow.GameObject.SetActive(true);
        }

        public void CloseWindow()
        {
            if (_currentWindow != null)
                _currentWindow.GameObject.SetActive(false);
            _currentWindow = null;
        }
    }
}


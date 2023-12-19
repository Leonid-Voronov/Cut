using UI.MetagameUI.Windows;
using UnityEngine;
using Zenject;

namespace UI.MetagameUI
{
    public class MetagameMediatorToUI : MonoBehaviour, IMetagameMediatorToUI
    {
        private IWindowHolder _windowHolder;
        private MenuWindow _menuWindow;
        private SettingsWindow _settingsWindow;

        [Inject]
        public void Construct(IWindowHolder windowHolder, MenuWindow menuWindow, SettingsWindow settingsWindow)
        {
            _windowHolder = windowHolder;
            _menuWindow = menuWindow;
            _settingsWindow = settingsWindow;
        }

        public void ShowMenuWindow() => _windowHolder.ChangeWindow(_menuWindow);

        public void ShowSettingsWindow() => _windowHolder.ChangeWindow(_settingsWindow);
        public void ClearView()
        {
            _menuWindow.GameObject.SetActive(false);
            _settingsWindow.GameObject.SetActive(false);
        }
    }

}


using Zenject;

namespace Cut
{
    public class GameStarter
    {
        private IComboSwitcher _comboSwitcher;

        [Inject]
        public GameStarter(IComboSwitcher comboSwitcher)
        {
            _comboSwitcher = comboSwitcher;
            StartGame();
        }

        private void StartGame()
        {
            _comboSwitcher.SwitchCombo();
        }
       
    }
}
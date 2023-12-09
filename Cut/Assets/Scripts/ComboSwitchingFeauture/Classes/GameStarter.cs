using UnityEngine;
using Zenject;

namespace Cut
{
    public class GameStarter : MonoBehaviour
    {
        private IComboSwitcher _comboSwitcher;

        [Inject]
        public void Construct(IComboSwitcher comboSwitcher)
        {
            _comboSwitcher = comboSwitcher;
        }

        private void Start()
        {
            _comboSwitcher.SwitchCombo();
        }
    }
}
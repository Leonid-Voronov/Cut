using System.Collections;
using UnityEngine;

namespace Cut
{
    public class ComboFinisherPrototype : IComboFinisher
    {
        private IComboSwitcher _comboSwitcher;

        public ComboFinisherPrototype(IComboSwitcher comboSwitcher)
        {
            _comboSwitcher = comboSwitcher;
        }

        public void FinishCombo()
        {
            _comboSwitcher.SwitchCombo();

            //viewStatistics
        }
    }
}
using System.Collections.Generic;
using Zenject;

namespace Cut
{
    public class ComboSwitcher : IComboSwitcher
    {
        private IComboInspector _comboInspector;
        private IComboGenerator _comboGenerator;
        private IRandomTemplateService _randomTemplateService;
        private IComboDisplay _comboDisplayer;

        [Inject]
        public ComboSwitcher(IComboInspector comboInspector, IComboGenerator comboGenerator, IRandomTemplateService randomTemplateService, IComboDisplay comboDisplayer)
        {
            _comboInspector = comboInspector;
            _comboGenerator = comboGenerator;
            _randomTemplateService = randomTemplateService;
            _comboDisplayer = comboDisplayer;
        }

        public void SwitchCombo()
        {
            List<int> generatedCombo = _comboGenerator.GenerateCombo(_randomTemplateService.GetRandomTemplate());
            _comboInspector.SetExpectedCombo(generatedCombo);
            _comboDisplayer.DisplayCombo(generatedCombo);
        }
    }
}


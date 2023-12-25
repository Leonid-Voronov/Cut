using System.Collections.Generic;
using Zenject;
using ComboGenerationFeature;

namespace ComboSwitchingFeature
{
    public class ComboSwitcher : IComboSwitcher
    {
        private IComboInspector _comboInspector;
        private IComboGenerator _comboGenerator;
        private IRandomTemplateService _randomTemplateService;

        [Inject]
        public ComboSwitcher(IComboInspector comboInspector, IComboGenerator comboGenerator, IRandomTemplateService randomTemplateService)
        {
            _comboInspector = comboInspector;
            _comboGenerator = comboGenerator;
            _randomTemplateService = randomTemplateService;
        }

        public void SwitchCombo()
        {
            List<int> generatedCombo = _comboGenerator.GenerateCombo(_randomTemplateService.GetRandomTemplate());
            _comboInspector.SetExpectedCombo(generatedCombo);
        }
    }
}
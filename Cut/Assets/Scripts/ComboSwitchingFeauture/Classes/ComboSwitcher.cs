using System.Collections.Generic;
using Zenject;
using ComboGenerationFeature;
using UI.GameplayUI;
using ComboSwitchingFeauture;

namespace ComboSwitchingFeature
{
    public class ComboSwitcher : IComboSwitcher
    {
        private IComboInspector _comboInspector;
        private IComboGenerator _comboGenerator;
        private IRandomTemplateService _randomTemplateService;
        private IGameplayMediatorToUI _gameplayMediator;
        private IComboConverter _comboConverter;

        [Inject]
        public ComboSwitcher(IComboInspector comboInspector, IComboGenerator comboGenerator, IRandomTemplateService randomTemplateService, IGameplayMediatorToUI gameplayMediator, IComboConverter comboConverter)
        {
            _comboInspector = comboInspector;
            _comboGenerator = comboGenerator;
            _randomTemplateService = randomTemplateService;
            _gameplayMediator = gameplayMediator;
            _comboConverter = comboConverter;
        }

        public void SwitchCombo()
        {
            List<int> generatedCombo = _comboGenerator.GenerateCombo(_randomTemplateService.GetRandomTemplate());
            _comboInspector.SetExpectedCombo(generatedCombo);
            List<string> stringCombo = _comboConverter.ConvertCombo(generatedCombo);
            _gameplayMediator.UpdateComboDisplay(stringCombo);
        }
    }
}
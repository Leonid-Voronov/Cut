using System.Collections.Generic;
using Zenject;
using ComboGenerationFeature;
using UI.GameplayUI;

namespace ComboSwitchingFeature
{
    public class ComboSwitcher : IComboSwitcher
    {
        private IComboInspector _comboInspector;
        private IComboGenerator _comboGenerator;
        private IRandomTemplateService _randomTemplateService;
        private IGameplayMediatorToUI _gameplayMediator;

        [Inject]
        public ComboSwitcher(IComboInspector comboInspector, IComboGenerator comboGenerator, IRandomTemplateService randomTemplateService, IGameplayMediatorToUI gameplayMediator)
        {
            _comboInspector = comboInspector;
            _comboGenerator = comboGenerator;
            _randomTemplateService = randomTemplateService;
            _gameplayMediator = gameplayMediator;
        }

        public void SwitchCombo()
        {
            List<int> generatedCombo = _comboGenerator.GenerateCombo(_randomTemplateService.GetRandomTemplate());
            _comboInspector.SetExpectedCombo(generatedCombo);
            _gameplayMediator.UpdateComboDisplay(generatedCombo);
        }
    }
}
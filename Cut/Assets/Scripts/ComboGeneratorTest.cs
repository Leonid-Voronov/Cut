using System.Collections.Generic;

namespace Cut
{
    public class ComboGeneratorTest
    {
        private RandomTemplateService _randomTemplateService;
        private ListConsoleDisplayer _listConsoleDisplayer;

        public ComboGeneratorTest()
        {
            _randomTemplateService = new RandomTemplateService();
            _listConsoleDisplayer = new ListConsoleDisplayer();
        }

        public void TestComboGenerator(CombosTemplatesSO _templates, ComboGenerator comboGenerator)
        {
            for (int i = 0; i < 20; i++)
            {
                List<int> randomTemplate = _randomTemplateService.GetRandomTemplate(_templates);
                _listConsoleDisplayer.ShowList(randomTemplate);

                List<int> result = comboGenerator.GenerateCombo(randomTemplate);
                _listConsoleDisplayer.ShowList(result);
            }
        }
        
    }
}
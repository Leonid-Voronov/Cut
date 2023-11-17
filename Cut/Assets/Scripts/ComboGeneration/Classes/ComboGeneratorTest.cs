using System.Collections.Generic;
using Zenject;

namespace Cut
{
    public class ComboGeneratorTest : IComboGeneratorTest
    {
        private IRandomTemplateService _randomTemplateService;
        private IListDisplayer _listDisplayer;
        private IComboGenerator _comboGenerator;

        private CombosTemplatesSO _templatesSO;

        [Inject]
        public ComboGeneratorTest(IRandomTemplateService randomTemplateService, IListDisplayer listDisplayer, IComboGenerator comboGenerator, CombosTemplatesSO combosTemplatesSO)
        {
            _randomTemplateService = randomTemplateService;
            _listDisplayer = listDisplayer;
            _comboGenerator = comboGenerator;
            _templatesSO = combosTemplatesSO;
        }

        public void TestComboGenerator()
        {
            for (int i = 0; i < 20; i++)
            {
                List<int> randomTemplate = _randomTemplateService.GetRandomTemplate(_templatesSO);
                _listDisplayer.ShowList(randomTemplate);

                List<int> result = _comboGenerator.GenerateCombo(randomTemplate);
                _listDisplayer.ShowList(result);
            }
        }
        
    }
}
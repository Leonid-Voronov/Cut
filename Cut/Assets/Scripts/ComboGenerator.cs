using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cut
{
    public class ComboGenerator : MonoBehaviour
    {
        [SerializeField] private List<int> _leftButtons = new List<int>();
        [SerializeField] private List<int> _rightButtons = new List<int>();
        [SerializeField] private CombosTemplatesSO _templates;

        private List<int> _buttons = new List<int>();

        private ButtonSideQualifier _buttonSideQualifier;
        private ListRandomService _listRandomService;
        private ListUniqueService _listUniqueService;
        private ComboGeneratorTest _comboGeneratorTest;


        private void Start () 
        {
            _buttons.AddRange(_leftButtons);
            _buttons.AddRange(_rightButtons);
            _buttonSideQualifier = new ButtonSideQualifier(_buttons);
            _listRandomService = new ListRandomService();
           
            _comboGeneratorTest = new ComboGeneratorTest();
            _comboGeneratorTest.TestComboGenerator(_templates, this);
        }

        private List<int> ChooseAvailableButtons(int changingButton, GenerationMode generationMode) //Not sure how to use it now
        {
            if (generationMode == GenerationMode.FullRandom)
            {
                return _buttons;
            }
            else
            {
                List<int> result = _buttonSideQualifier.IsButtonLeft(changingButton) ? _leftButtons : _rightButtons;
                return result;
            }
        }

        public List<int> GenerateCombo(List<int> template)
        {
            List<int> result = new List<int>(template);
            List<int> uniqueElements = _listUniqueService.GetUniqueElements(template);
            List<int> changedUniqueElements = new List<int>(uniqueElements);
            List<bool> flagList = Enumerable.Repeat(element: false, count: result.Count).ToList();
            List<int> availableButtons = new List<int>(_buttons);

            for (int i = 0; i < changedUniqueElements.Count;  i++) 
            {
                changedUniqueElements[i] = _listRandomService.GetRandomAvailableButton(ref availableButtons);

                for (int j = 0; j < result.Count; j++)
                    if (result[j] == uniqueElements[i] && flagList[j] == false)
                    {
                        result[j] = changedUniqueElements[i];
                        flagList[j] = true;
                    }
            }

            return result;
        }
    }

    public enum GenerationMode
    {
        FullRandom = 0,
        AccordinglyWithHand = 1
    }
}


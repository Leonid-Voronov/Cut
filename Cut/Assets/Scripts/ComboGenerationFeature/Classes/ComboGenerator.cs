using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace ComboGenerationFeature
{
    public class ComboGenerator : IComboGenerator
    {
        private IButtonSideQualifier _buttonSideQualifier;
        private IListRandomService _listRandomService;
        private IListUniqueService _listUniqueService;

        private ButtonsHolderSO _buttonsHolderSO;

        [Inject]
        private void Construct(IButtonSideQualifier buttonSideQualifier, IListRandomService listRandomService, IListUniqueService listUniqueService, ButtonsHolderSO buttonsHolder)
        {
            _buttonSideQualifier = buttonSideQualifier;
            _buttonsHolderSO = buttonsHolder;
            _listRandomService = listRandomService;
            _listUniqueService = listUniqueService;
        }

        public List<int> GenerateCombo(List<int> template)
        {
            List<int> result = new List<int>(template);
            List<int> uniqueElements = _listUniqueService.GetUniqueElements(template);
            List<int> changedUniqueElements = new List<int>(uniqueElements);
            List<bool> flagList = Enumerable.Repeat(element: false, count: result.Count).ToList(); //to change items in result only once
            List<int> availableButtons = new List<int>(_buttonsHolderSO.Buttons);

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

        private List<int> ChooseAvailableButtons(int changingButton, GenerationMode generationMode) //Not sure how to use it now
        {
            if (generationMode == GenerationMode.FullRandom)
            {
                return _buttonsHolderSO.Buttons;
            }
            else
            {
                List<int> result = _buttonSideQualifier.IsButtonLeft(changingButton) ? _buttonsHolderSO.LeftButtons : _buttonsHolderSO.RightButtons;
                return result;
            }
        }
    }

    public enum GenerationMode
    {
        FullRandom = 0,
        AccordinglyWithHand = 1
    }
}


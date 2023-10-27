using System.Collections;
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

        private void Start () 
        {
            _buttons.AddRange(_leftButtons);
            _buttons.AddRange(_rightButtons);
            _buttonSideQualifier = new ButtonSideQualifier(_buttons);

            for (int i = 0; i < 20; i++)
            {
                List<int> randomTemplate = GetRandomTemplate(_templates);
                /*string f = "";
                foreach (int item in  randomTemplate) { f += item; }
                Debug.Log(f);*/

                List<int> result = GenerateCombo(randomTemplate);
                /*string k = "";
                foreach(int item in result) { k += item; }
                Debug.Log(k);*/
            }
                
        }

        private List<int> GetRandomTemplate(CombosTemplatesSO templates)
        {
            int randomIndex = Random.Range(0, templates.Combos.Count);
            return templates.GetCombo(randomIndex);
        }

        private List<int> GetUniqueElements(List<int> template) 
        {
            return (from x in template select x).Distinct().ToList();
        }

        private int GetRandomAvailableButton(ref List<int> availableButtons)
        {
            int randomIndex = Random.Range(0, availableButtons.Count);
            int result = availableButtons[randomIndex];
            availableButtons.RemoveAt(randomIndex);
            return result;
        }

        private List<int> ChooseAvailableButtons(int changingButton, GenerationMode generationMode)
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
            List<int> uniqueElements = GetUniqueElements(template);
            List<int> changedUniqueElements = new List<int>(uniqueElements);
            List<bool> flagList = Enumerable.Repeat(element: false, count: result.Count).ToList();
            List<int> availableButtons = new List<int>(_buttons);

            for (int i = 0; i < changedUniqueElements.Count;  i++) 
            {
                changedUniqueElements[i] = GetRandomAvailableButton(ref availableButtons);

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
        FullRandom,
        AccordinglyWithHand
    }
}


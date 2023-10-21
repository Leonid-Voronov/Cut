using UnityEngine;
using static UnityEngine.EventSystems.PointerEventData;

namespace Cut
{
    public class InputIntepretation : MonoBehaviour
    {
        private void OnEnable()
        {
            InputButton.ButtonPressed += AddButtonToCombo;
        }

        private void AddButtonToCombo(object snder, InputButtonPressedEventArgs e)
        {
            Debug.Log(e.PressedButton);
        }

        private void OnDisable()
        {
            InputButton.ButtonPressed -= AddButtonToCombo;
        }
    }
}


using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public class ListRandomService 
    {
        public int GetRandomAvailableButton(ref List<int> availableButtons)
        {
            int randomIndex = Random.Range(0, availableButtons.Count);
            int result = availableButtons[randomIndex];
            availableButtons.RemoveAt(randomIndex);
            return result;
        }
    }
}
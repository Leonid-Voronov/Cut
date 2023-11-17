using UnityEngine;
using Zenject;

namespace Cut
{
    public class Tester : MonoBehaviour
    {
        private IComboGeneratorTest _comboGeneratorTest;

        [Inject]
        private void Construct(IComboGeneratorTest comboGeneratorTest)
        {
            _comboGeneratorTest = comboGeneratorTest;
        }

        private void Start()
        {
            _comboGeneratorTest.TestComboGenerator();
        }
    }
}
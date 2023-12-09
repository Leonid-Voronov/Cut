using UnityEngine;

namespace Cut
{
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameModes", order = 3)]
    public class GameConfigSO : ScriptableObject
    {
        [SerializeField] private float _prepTime;
        [SerializeField] private StartTimerCondition _startTimerCondition;
        [SerializeField] private bool _switchComboAfterFail;
        public float PrepTime => _prepTime;
        public bool FailSwitch => _switchComboAfterFail;
        public StartTimerCondition StartTimerCondition => _startTimerCondition;
    }
}


using UnityEngine;

namespace GameModeFeature
{
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode", order = 3)]
    public class GameModeSO : ScriptableObject
    {
        [SerializeField] private float _prepTime;
        [SerializeField] private StartTimerCondition _startTimerCondition;
        [SerializeField] private bool _switchComboAfterFail;
        [SerializeField] private ComboDisplayMode _comboDisplayMode;
        public float PrepTime => _prepTime;
        public bool FailSwitch => _switchComboAfterFail;
        public StartTimerCondition StartTimerCondition => _startTimerCondition;
        public ComboDisplayMode ComboDisplayMode => _comboDisplayMode;
    }
}


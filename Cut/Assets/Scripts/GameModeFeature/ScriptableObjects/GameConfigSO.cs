using UnityEngine;

namespace Cut
{
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameModes", order = 3)]
    public class GameConfigSO : ScriptableObject
    {
        [SerializeField] private bool _unlimitedTime;
        public bool UnlimitedTime => _unlimitedTime;
    }
}


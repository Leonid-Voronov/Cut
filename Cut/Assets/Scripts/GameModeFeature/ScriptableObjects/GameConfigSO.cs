using UnityEngine;

namespace Cut
{
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameModes", order = 3)]
    public class GameConfigSO : ScriptableObject
    {
        [SerializeField] private bool _unlimitedTime;
        [SerializeField] private float _prepTime;
        public bool UnlimitedTime => _unlimitedTime;
        public float PrepTime => _prepTime;
    }
}


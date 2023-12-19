using UnityEngine;

namespace Cut
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 4)]
    public class GameConfigSO : ScriptableObject
    {
        [SerializeField] private StartMode _startMode;
        public StartMode StartMode => _startMode;
    }

    public enum StartMode
    {
        Gameplay = 0,
        GameSettingsWindow = 1,
        MainMenu = 3
    }
}


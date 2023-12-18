using Cut;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.GameModeFeature
{
    public class GameModeHolder
    {
        private Dictionary<GameMode, GameModeSO> _gameModes;
        private GameModeSO _currentGameMode;
        public GameModeSO CurrentGameMode => _currentGameMode;

        [Inject]
        public GameModeHolder(Dictionary<GameMode, GameModeSO> gameModes, GameModeSO defaultGameMode)
        {
            _gameModes = gameModes;
            _currentGameMode = defaultGameMode;
        }

        private void SetCurrentGameMode(object sender, GameModeSetEventArgs e)
        {
            _currentGameMode = _gameModes[e.GameMode];
        }

        public void SetCurrentGameMode(GameMode newGameModeName)
        {
            _currentGameMode = _gameModes[newGameModeName];
        }
    }
}

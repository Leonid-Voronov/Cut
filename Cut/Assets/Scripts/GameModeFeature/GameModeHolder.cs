using ComboSwitchingFeature;
using System.Collections.Generic;
using Zenject;

namespace GameModeFeature
{
    public class GameModeHolder
    {
        private Dictionary<GameMode, GameModeSO> _gameModes;
        private GameModeSO _currentGameMode;
        private ComboConverterHolder _comboConverterHolder;
        public GameModeSO CurrentGameMode => _currentGameMode;

        [Inject]
        public GameModeHolder(Dictionary<GameMode, GameModeSO> gameModes, GameModeSO defaultGameMode, ComboConverterHolder comboConverterHolder)
        {
            _gameModes = gameModes;
            _currentGameMode = defaultGameMode;
            _comboConverterHolder = comboConverterHolder;
        }

        private void SetCurrentGameMode(object sender, GameModeSetEventArgs e)
        {
            _currentGameMode = _gameModes[e.GameMode];
            _comboConverterHolder.SetComboConverter(_currentGameMode.ComboDisplayMode);
        }

        public void SetCurrentGameMode(GameMode newGameModeName)
        {
            _currentGameMode = _gameModes[newGameModeName];
            _comboConverterHolder.SetComboConverter(_currentGameMode.ComboDisplayMode);
        }
    }
}


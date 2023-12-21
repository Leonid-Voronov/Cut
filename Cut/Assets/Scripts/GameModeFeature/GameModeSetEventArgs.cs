using System;

namespace GameModeFeature
{
    public class GameModeSetEventArgs : EventArgs
    {
        public GameModeSetEventArgs(GameMode gameMode) { _gameMode = gameMode; }
        private GameMode _gameMode;
        public GameMode GameMode => _gameMode;
    }
}
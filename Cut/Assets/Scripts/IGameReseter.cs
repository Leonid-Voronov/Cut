using System;

namespace Core
{
    public interface IGameReseter 
    {
        public void ResetGame();
        public event EventHandler GameReset;
    }
}
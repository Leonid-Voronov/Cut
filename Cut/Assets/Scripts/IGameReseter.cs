using System;

namespace Assets.Scripts
{
    public interface IGameReseter 
    {
        public void ResetGame();
        public event EventHandler GameReset;
    }
}
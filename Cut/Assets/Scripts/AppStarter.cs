﻿using Assets.Scripts.UI;
using Cut;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class AppStarter : MonoBehaviour
    {
        private GameStarter _gameStarter;
        private GameConfigSO _gameConfigSO;
        private IUIInitializer _UIInitializer;

        [Inject]
        public void Construct(GameStarter gameStarter, GameConfigSO gameConfigSO, IUIInitializer uIInitializer) 
        {
            _gameStarter = gameStarter;
            _gameConfigSO = gameConfigSO;
            _UIInitializer = uIInitializer;
        }

        private void Start()
        {
            _UIInitializer.InitializeUI();

            if (_gameConfigSO.StartMode == StartMode.Gameplay)
                _gameStarter.StartGame();
        }
    }
}
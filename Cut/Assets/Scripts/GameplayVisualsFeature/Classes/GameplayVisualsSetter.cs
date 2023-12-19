using TagComponents;
using UnityEngine;
using Zenject;

namespace GameplayVisualsFeature
{
    public class GameplayVisualsSetter
    {
        private VisualsPresetHolder _gameplayVisualsHolder;
        private Transform _gameplayZoneTransform;
        private IEnvironmentObjectsDestroyer _environmentObjectsDestroyer;
        private IEnvironmentFramer _environmentFramer;

        [Inject]
        public GameplayVisualsSetter(VisualsPresetHolder gameplayVisualsHolder, IGameplayZone gameplayZone, IEnvironmentObjectsDestroyer environmentObjectsDestroyer, IEnvironmentFramer environmentFramer)
        {
            _gameplayVisualsHolder = gameplayVisualsHolder;
            _gameplayZoneTransform = gameplayZone.Transform;
            _environmentObjectsDestroyer = environmentObjectsDestroyer;
            _environmentFramer = environmentFramer;
        }

        public void SwitchGameplayVisualsOnScene()
        {
            _environmentObjectsDestroyer.DestroyEnvironmentObjects();
            CreateNewEnvironment();
        }

        private void CreateNewEnvironment()
        {
            GameObject newEnvironment = GameObject.Instantiate(_gameplayVisualsHolder.CurrentVisualPreset.EnvironmentPrefab, _gameplayZoneTransform.position, Quaternion.identity, _gameplayZoneTransform);
            EnvironmentChildrenHolder children = newEnvironment.GetComponent<EnvironmentChildrenHolder>();
            _environmentFramer.FrameEnvironment(children.BackgroundTransform, children.OverlayTransform);
        }
    }
}


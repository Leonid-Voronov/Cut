using UnityEngine;
using Zenject;

namespace GameplayVisualsFeature
{
    public class EnvironmentFramer : IEnvironmentFramer
    {
        private IScaleHolder _scaleHolder;

        [Inject]
        public void Construct(IScaleHolder scaleHolder)
        {
            _scaleHolder = scaleHolder;
        }

        public void FrameEnvironment(Transform backgroundTransform, Transform overlayTransform)
        {
            backgroundTransform.localScale = _scaleHolder.Scale;
            overlayTransform.localScale = _scaleHolder.Scale;
        }
    }
}
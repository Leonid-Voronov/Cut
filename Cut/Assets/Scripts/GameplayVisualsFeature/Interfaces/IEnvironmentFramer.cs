using UnityEngine;

namespace GameplayVisualsFeature
{
    public interface IEnvironmentFramer
    {
        public void FrameEnvironment(Transform backgroundTransform, Transform overlayTransform);
    }
}
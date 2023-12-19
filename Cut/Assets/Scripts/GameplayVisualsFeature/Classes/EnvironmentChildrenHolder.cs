using UnityEngine;

namespace GameplayVisualsFeature
{
    public class EnvironmentChildrenHolder : MonoBehaviour
    {
        [SerializeField] private Transform _backgroundTransform;
        [SerializeField] private Transform _overlayTransform;
        public Transform BackgroundTransform => _backgroundTransform;
        public Transform OverlayTransform => _overlayTransform;
    }
}


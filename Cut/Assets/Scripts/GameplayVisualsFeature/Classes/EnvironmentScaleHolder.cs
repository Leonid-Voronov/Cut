using UnityEngine;

namespace GameplayVisualsFeature
{
    public class EnvironmentScaleHolder : MonoBehaviour, IScaleHolder
    {
        [SerializeField] private Transform _testBackgroundTransform;
        public Vector3 Scale => _testBackgroundTransform.localScale;
    }
}


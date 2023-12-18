using UnityEngine;

namespace GameplayVisualsFeature
{
    [CreateAssetMenu(fileName = "VisualPack", menuName = "ScriptableObjects/Visuals", order = 4)]
    public class VisualsPresetSO : ScriptableObject
    {
        [SerializeField] private GameObject _environmentPrefab;
        public GameObject EnvironmentPrefab => _environmentPrefab;
    }
}


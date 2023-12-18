using System.Collections.Generic;
using TagComponents;
using UnityEngine;
using Zenject;

namespace GameplayVisualsFeature
{
    public class EnvironmentObjectsDestroyer : IEnvironmentObjectsDestroyer
    {
        private Transform _gameplayZoneTransform;
        [Inject]
        public EnvironmentObjectsDestroyer(IGameplayZone gameplayZone)
        {
            _gameplayZoneTransform = gameplayZone.Transform;
        }

        public void DestroyEnvironmentObjects()
        {
            List<GameObject> environmentObjects = FindEnvironmentComponents(_gameplayZoneTransform);
            foreach (GameObject environmentObject in environmentObjects)
                GameObject.Destroy(environmentObject);
        }

        private List<GameObject> FindEnvironmentComponents(Transform transform) //use this instead of GetComponentsInChildren to avoid allocation
        {
            List<GameObject> result = new List<GameObject>();
            foreach (Transform child in transform)
            {
                if (child.GetComponent<TagComponents.Environment>())
                {
                    result.Add(child.gameObject);
                }
            }

            return result;
        }
    }
}
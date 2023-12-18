using System.Collections.Generic;
using UnityEngine;

namespace GameplayVisualsFeature
{
    public class EnvironmentObjectsDestroyer : IEnvironmentObjectsDestroyer
    {
        public void DestroyEnvironmentObjects(Transform parentTransform)
        {
            List<GameObject> environmentObjects = FindEnvironmentComponents(parentTransform);
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
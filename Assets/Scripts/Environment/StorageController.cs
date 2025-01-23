using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Environment
{
    public class StorageController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _smallPoints;
    
        public void SpawnItems(List<GameObject> items)
        {
            var spawnPoints = _smallPoints.GetRandomElements(3);

            for (var index = 0; index < spawnPoints.Count; index++)
            {
                var spawnPoint = spawnPoints[index];
                Instantiate(items[index], spawnPoint);
            }
        }
    }
}
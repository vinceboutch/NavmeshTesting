using System;
using Navmesh_Agent;
using UnityEngine;

namespace Spawners
{
    public class EntitiesSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject destinationA = null;
        [SerializeField]
        private GameObject destinationB = null;
        
        [Tooltip("The number of entities to spawn of start.")] [SerializeField]
        private int numberOfEntitiesToSpawn = 10;

        [Tooltip("The prefab of the entities to spawn.")] [SerializeField]
        private GameObject prefabToSpawn = null;

        private void Awake()
        {
            if (numberOfEntitiesToSpawn <= 0)
            {
                throw new ArgumentOutOfRangeException($"The number of entities to spawn must be superior to zero.");
            }

            if (prefabToSpawn == null)
            {
                Debug.Log("Prefab not found");
            }
        }

        private void Start()
        {
            for (int i = 0; i < numberOfEntitiesToSpawn; ++i)
            {
                GameObject currentInstantiate = Instantiate(prefabToSpawn);
                DestinationSetter currentDestinationSetter = currentInstantiate.GetComponent<DestinationSetter>();
                currentDestinationSetter.destinationA = destinationA;
                currentDestinationSetter.destinationB = destinationB;
                currentDestinationSetter.Init();
            }
        }
    }
}
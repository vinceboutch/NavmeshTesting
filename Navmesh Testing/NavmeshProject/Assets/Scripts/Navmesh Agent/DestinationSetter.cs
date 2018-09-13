using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Navmesh_Agent
{
    public enum CurrentDestinationName
    {
        A,
        B
    }
    public class DestinationSetter : MonoBehaviour
    {
        private const float DESTINATION_RADIUS_X = 19.5f;
        private const float DESTINATION_RADIUS_Z = 0.5f;
        
        public GameObject destinationA = null;
        public GameObject destinationB = null;
        [SerializeField] private CurrentDestinationName currentDestination = CurrentDestinationName.A;

        private NavMeshAgent navMeshAgent;
        
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
            {
                Debug.Log("NavMeshAgent not found!");
            }
        }

        private Vector3 GenerateDestinationPoint(Vector3 destinationInitialPosition)
        {
            if (Random.Range(0, 100) < 50)
            {
                return new Vector3(destinationInitialPosition.x + Random.Range(0, DESTINATION_RADIUS_X), 0, 
                    destinationInitialPosition.z + Random.Range(0, DESTINATION_RADIUS_Z));
            }
            else
            {
                return new Vector3(destinationInitialPosition.x - Random.Range(0, DESTINATION_RADIUS_X), 0, 
                    destinationInitialPosition.z + Random.Range(0, DESTINATION_RADIUS_Z));
            }
        }

        private void ChangeCurrentDestination()
        {
            int currentIndex = (((int) currentDestination) + 1) % Enum.GetValues(typeof(CurrentDestinationName)).Length;
            currentDestination = (CurrentDestinationName) currentIndex;
        }

        private Vector3 GetCurrentTargetPosition()
        {
            switch (currentDestination)
            {
                case CurrentDestinationName.A:
                    return GenerateDestinationPoint(destinationA.transform.position);
                    break;
                case CurrentDestinationName.B:
                    return GenerateDestinationPoint(destinationB.transform.position);
                    break;
                default:
                    return transform.position;
                    break;
            }
        }

        private void UpdateDestination()
        {
            navMeshAgent?.SetDestination(GetCurrentTargetPosition());
        }

        public void NotifyDestinationFound(CurrentDestinationName destinationName)
        {
            if (destinationName == currentDestination)
            {
                ChangeCurrentDestination();
                UpdateDestination();
            }
        }

        public void Init()
        {
            UpdateDestination();
        }
    }
}
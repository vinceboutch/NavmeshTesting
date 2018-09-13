using Navmesh_Agent;
using UnityEngine;

namespace Destinations
{
    public class OnEnterDestinationTrigger : MonoBehaviour
    {
        [SerializeField]
        private CurrentDestinationName destinationName = CurrentDestinationName.A;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.IA_TAG))
            {
                other.GetComponent<DestinationSetter>().NotifyDestinationFound(destinationName);
            }
        }
    }
}
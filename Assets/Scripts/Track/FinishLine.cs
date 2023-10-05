using UnityEngine;

namespace Track
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider carCollider)
        {
            Debug.Log($"{carCollider.transform.parent.name} Won");
        }
    }
}
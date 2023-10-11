using UnityEngine;

namespace Track
{
    public class SpeedDecrease : MonoBehaviour
    {
        public float DecreaseDragAmount;
        private float originalDrag;

        private void OnTriggerEnter(Collider carCollider)
        {
            Rigidbody attachedRigidbody = carCollider.attachedRigidbody;
            originalDrag = attachedRigidbody.drag;

            attachedRigidbody.drag = DecreaseDragAmount;
        }

        private void OnTriggerExit(Collider carCollider)
        {
            carCollider.attachedRigidbody.drag = originalDrag;
        }
    }
}
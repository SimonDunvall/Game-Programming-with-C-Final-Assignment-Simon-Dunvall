using UnityEngine;

namespace Track
{
    public class SpeedBoost : MonoBehaviour
    {
        public int BoostAmount;

        private void OnTriggerEnter(Collider carCollider)
        {
            carCollider.attachedRigidbody.AddForce(carCollider.attachedRigidbody.transform.forward * BoostAmount,
                ForceMode.VelocityChange);
        }
    }
}
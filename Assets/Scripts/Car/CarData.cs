using UnityEngine;

namespace Car
{
    public class CarData : MonoBehaviour
    {
        internal int NumberOfLapsCompleted;

        internal static CarData GetCar(Collider carCollider)
        {
            return carCollider.GetComponentInParent<CarData>();
        }
    }
}
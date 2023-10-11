using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class CheckPoint : MonoBehaviour
    {
        internal readonly List<int> carsPassed = new List<int>();

        private void OnTriggerEnter(Collider carCollider)
        {
            if (!carsPassed.Contains(carCollider.GetInstanceID()))
            {
                carsPassed.Add(carCollider.GetInstanceID());
            }
        }
    }
}
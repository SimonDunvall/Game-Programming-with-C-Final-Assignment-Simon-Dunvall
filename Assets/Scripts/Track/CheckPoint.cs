using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class CheckPoint : MonoBehaviour
    {
        public List<int> carsPassed = new List<int>();

        private void OnTriggerEnter(Collider checkPointCollider)
        {
            if (!carsPassed.Contains(checkPointCollider.GetInstanceID()))
            {
                carsPassed.Add(checkPointCollider.GetInstanceID());
            }
        }
    }
}
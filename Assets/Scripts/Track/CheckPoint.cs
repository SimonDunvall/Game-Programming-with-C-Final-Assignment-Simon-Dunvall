using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class CheckPoint : MonoBehaviour
    {
        public bool checkPointDone;

        private void OnTriggerEnter(Collider checkPointCollider)
        {
            checkPointDone = true;
        }
    }
}
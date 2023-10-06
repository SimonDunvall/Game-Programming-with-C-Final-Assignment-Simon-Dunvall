using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace Track
{
    public class FinishLine : MonoBehaviour
    {
        public int NumberOfLapsCompleted;

        private void OnTriggerEnter(Collider carCollider)
        {
            var checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
            List<bool> doneCheckPoints = new List<bool>();

            foreach (var checkPoint in checkPoints)
            {
                var cp = checkPoint.GetComponent<CheckPoint>();
                doneCheckPoints.Add(cp.checkPointDone);
            }

            if (doneCheckPoints.Count() == checkPoints.Count() && doneCheckPoints.TrueForAll(e => e))
            {
                NumberOfLapsCompleted++;

                foreach (var checkPoint in checkPoints)
                {
                    var cp = checkPoint.GetComponent<CheckPoint>();
                    cp.checkPointDone = false;
                }


                if (GameState.getNumberOfLaps() <= NumberOfLapsCompleted)
                {
                    Debug.Log($"{carCollider.transform.parent.name} Won");
                }
            }
        }
    }
}
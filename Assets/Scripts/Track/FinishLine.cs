using System.Collections.Generic;
using System.Linq;
using Car;
using Game;
using UnityEngine;

namespace Track
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider carCollider)
        {
            GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
            List<bool> doneCheckPoints = (from checkPoint in checkPoints
                select checkPoint.GetComponent<CheckPoint>()
                into cp
                where cp.carsPassed.Contains(carCollider.GetInstanceID())
                select true).ToList();

            if (doneCheckPoints.Count() != checkPoints.Count() || !doneCheckPoints.TrueForAll(e => e)) return;
            {
                CarManager car = carCollider.GetComponentInParent<CarManager>();
                car.NumberOfLapsCompleted++;

                foreach (GameObject checkPoint in checkPoints)
                {
                    CheckPoint cp = checkPoint.GetComponent<CheckPoint>();
                    cp.carsPassed.Remove(carCollider.GetInstanceID());
                }

                if (GameState.getNumberOfLaps() <= car.NumberOfLapsCompleted)
                {
                    Debug.Log($"{carCollider.transform.parent.name} Won");
                }
            }
        }
    }
}
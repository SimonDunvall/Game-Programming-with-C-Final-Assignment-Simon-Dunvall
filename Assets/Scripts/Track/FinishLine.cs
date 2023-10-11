using System;
using System.Collections.Generic;
using System.Linq;
using Car;
using Game;
using JetBrains.Annotations;
using UnityEngine;

namespace Track
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider carCollider)
        {
            GameObject[] allCheckPoints = GetCheckPoints();
            bool[] passedCheckPoints = GetPassedCheckPoint(allCheckPoints, carCollider);

            if (passedCheckPoints.Count() < allCheckPoints.Count() ||
                !Array.TrueForAll(passedCheckPoints, b => b)) return;

            CarData car = CarData.GetCar(carCollider);
            car.NumberOfLapsCompleted++;

            RemoveCarFromCheckPoints(allCheckPoints, carCollider);

            GameSettings gameSettings = ScriptableObject.CreateInstance<GameSettings>();
            if (gameSettings.getNumberOfLaps() > car.NumberOfLapsCompleted) return;

            GameState.LoadGameOver().GameWon(carCollider.transform.parent.name);
        }

        private void RemoveCarFromCheckPoints(IEnumerable<GameObject> checkPoints, [NotNull] Collider carCollider)
        {
            if (carCollider == null) throw new ArgumentNullException(nameof(carCollider));
            foreach (GameObject checkPoint in checkPoints)
            {
                GetCheckPoint(checkPoint).carsPassed.Remove(carCollider.GetInstanceID());
            }
        }

        private CheckPoint GetCheckPoint(GameObject checkPoint)
        {
            return checkPoint.GetComponent<CheckPoint>();
        }

        private bool[] GetPassedCheckPoint(IEnumerable<GameObject> allCheckPoints, [NotNull] Collider col)
        {
            if (col == null) throw new ArgumentNullException(nameof(col));
            return (from checkPoint in allCheckPoints
                select GetCheckPoint(checkPoint)
                into cp
                where cp.carsPassed.Contains(col.GetInstanceID())
                select true).ToArray();
        }

        private GameObject[] GetCheckPoints()
        {
            return GameObject.FindGameObjectsWithTag("CheckPoint");
        }
    }
}
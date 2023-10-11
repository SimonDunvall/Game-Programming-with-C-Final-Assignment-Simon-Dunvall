using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("Scenes")] public string mainMenuSceneName;
        public List<string> tracksName;

        [Header("Other Settings")] public bool isGamePaused;
        public int numberOfLaps;

        internal void SetDefaultValues()
        {
            isGamePaused = false;
        }

        internal int getNumberOfLaps()
        {
            return numberOfLaps;
        }
    }
}
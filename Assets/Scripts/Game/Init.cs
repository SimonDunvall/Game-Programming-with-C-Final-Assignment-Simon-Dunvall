using UnityEngine;

namespace Game
{
    public static class Init
    {
        private static GameSettings gameSettings;

        [RuntimeInitializeOnLoadMethod]
        public static void InitGame()
        {
            LoadSettings();

            var go = new GameObject
            {
                name = "GameState"
            };
            var gameState = go.AddComponent<GameState>();
            gameState.Initialize(gameSettings);
        }

        private static void LoadSettings()
        {
            gameSettings = Resources.Load<GameSettings>("GameSettings");
        }
    }
}
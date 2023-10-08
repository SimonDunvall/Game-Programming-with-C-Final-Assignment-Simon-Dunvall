using UnityEngine;

namespace Game
{
    public abstract class Init
    {
        private static GameSettings gameSettings;

        [RuntimeInitializeOnLoadMethod]
        public static void InitGame()
        {
            LoadSettings();
            LoadGameState();
        }

        private static void LoadSettings()
        {
            gameSettings = Resources.Load<GameSettings>("GameSettings");
            gameSettings.SetDefaultValues();
        }

        private static void LoadGameState()
        {
            var go = new GameObject
            {
                name = "GameState"
            };
            var gameState = go.AddComponent<GameState>();
            gameState.Initialize(gameSettings);
        }
    }
}
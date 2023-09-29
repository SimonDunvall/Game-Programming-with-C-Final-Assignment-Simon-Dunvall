using Resources;
using UnityEngine;

public static class Init
{
    [RuntimeInitializeOnLoadMethod]
    public static void InitGame()
    {
        var go = new GameObject
        {
            name = "GameState"
        };
        var gameState = go.AddComponent<GameState>();
        gameState.Initialize();
    }
}
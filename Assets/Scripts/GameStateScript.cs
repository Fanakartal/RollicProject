using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript
{
    public enum GameState
    {
        Waiting,
        Playing,
        Won,
        Lost,
        ToNextLevel
    };

    /*public static GameStateScript(GameState gameState)
    {
        gameState = GameState.InMainMenu;
    }*/
}

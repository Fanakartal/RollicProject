using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript
{
    public enum GameState
    {
        InMainMenu,
        InShop,
        InGame,
        Waiting,
        Playing,
        Won,
        Lost,
        InGameMenu
    };

    /*public static GameStateScript(GameState gameState)
    {
        gameState = GameState.InMainMenu;
    }*/
}

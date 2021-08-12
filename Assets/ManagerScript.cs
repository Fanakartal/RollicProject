using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateScript;

public class ManagerScript : MonoBehaviour
{
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public GameObject gameManager;
    
    public Text tapToPlayText;
    
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && tapToPlayText.IsActive())
        {
            tapToPlayText.gameObject.SetActive(false);
            gameManager.GetComponent<ManagerScript>().gameState = GameStateScript.GameState.Playing;
        }
    }
}

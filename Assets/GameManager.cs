using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;
    private void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            gameEnded = true;
        }
    }

    void EndGame()
    {
        
    }
}

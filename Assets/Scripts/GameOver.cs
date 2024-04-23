using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI rounds;

    private void OnEnable()
    {
        rounds.text = "Rounds Survived: " + PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {

    }
    public void selectMissleTurret()
    {
        Debug.Log("Missle Turret Purchased");
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public void mainMenu()
    {
        //Debug.Log("mainmenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void restartGame()
    {
        FindObjectOfType<GameManager>().newGame();
        SceneManager.LoadScene("Level1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        FindObjectOfType<GameManager>().loadLevel(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

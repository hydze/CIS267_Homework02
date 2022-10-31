using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 0;

        loadLevel(1);
    }

    private void loadLevel(int lvl)
    {
        this.level = lvl;

        SceneManager.LoadScene("Level" + lvl);
    }

    public void restartLevel()
    {

    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void onBrickHit(BrickBehaviour brick)
    {
        score += brick.points;
        Debug.Log(score);
    }

    public void onBorderHit()
    {
        lives--;
        checkLives();
    }

    public void checkLives()
    {
        if (lives >= 0)
        {
            restartLevel();
        }
        else gameOver();
    }
}

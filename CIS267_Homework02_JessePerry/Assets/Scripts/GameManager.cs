using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PuckBehaviour puck { get; set; }
    public PuckBehaviour puck2 { get; set; }
    public PuckBehaviour puck3 { get; set; }
    public PaddleMovement paddle { get; set; }
    public BrickBehaviour[] bricks { get; set; }

    public int level = 1;
    public int score = 0;
    public int lives = 3;
    public bool isFlipped = false;
    public bool isRapid = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += onLevelLoad;
    }

    private void Start()
    {
        newGame();
    }

    public void newGame()
    {
        score = 0;
        lives = 3;

        loadLevel(1);
    }

    private void loadLevel(int lvl)
    {
        this.level = lvl;

        SceneManager.LoadScene("Level" + lvl);
    }

    public void onLevelLoad(Scene scene, LoadSceneMode mode)
    {
        puck = FindObjectOfType<PuckBehaviour>();
        paddle = FindObjectOfType<PaddleMovement>();
        bricks = FindObjectsOfType<BrickBehaviour>();
    }

    private void resetLevel()
    {
        paddle.resetPaddle();
        puck.resetPuck();
        destroyExtraPucks();
        isFlipped = false;

        //for (int i = 0; i < bricks.Length; i++)
        //{
        //    bricks[i].resetBrick();
        //}
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void onBrickHit(BrickBehaviour brick)
    {
        score += brick.points;
        //Debug.Log(score);
    }

    public void onBorderHit()
    {
        //Debug.Log("enter function");
        lives--;
        checkLives();
    }

    public void invokeReverseFlip()
    {
        Invoke("reverseFlip", 8);
    }

    public void reverseFlip()
    {
        isFlipped = false;
    }

    //---------------------------
    public void invokeReverseRapid()
    {
        Invoke("reverseRapid", 5);
    }

    public void reverseRapid()
    {
        isRapid = false;
    }
    //----------------------------
    public void checkLives()
    {
        if (lives > 0)
        {
            resetLevel();
        }
        else gameOver();
    }

    public string scoreString()
    {
        string s = "score: " + score;
        return s;
    }

    public void destroyExtraPucks()
    {
        foreach (GameObject puckAmt in GameObject.FindGameObjectsWithTag("Puck"))
        {
            if (puckAmt.name == "Puck(Clone)")
            {
                Destroy(puckAmt);
            }
        }
    }
}

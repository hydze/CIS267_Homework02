using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public int health { get; set;}
    public SpriteRenderer sr { get; set; }
    public BrickBehaviour[] brick;
    public Sprite[] condition;
    public bool unbreakable;
    public int points = 1000;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        resetBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Puck")
        {
            brickHit();
        }
    }

    private void generateRandomHealth()
    {
        for (int i = 0; i > 50; i++)
        {
            
        }
    }

    public void resetBrick()
    {
        this.gameObject.SetActive(true);

        if (!unbreakable)
        {
            health = condition.Length;
            sr.sprite = condition[health - 1];
        }
    }

    private void brickHit()
    {
        if (unbreakable) return;

        health--;

        if(health<= 0)
        {
            this.gameObject.SetActive(false);
        }
        else sr.sprite = condition[health - 1];

        FindObjectOfType<GameManager>().onBrickHit(this);
    }
}

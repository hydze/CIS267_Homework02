using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public int health { get; set;}
    public SpriteRenderer sr { get; set; }
    public BrickBehaviour[] brick;
    public Sprite[] condition;
    public int points = 1000;
    private int randHeatlh;
    //public bool canDrop;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        resetBrick();
        generateRandomHealth();
    }

    private void Update()
    {
        
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
        randHeatlh = Random.Range(1, 4);
        health = randHeatlh;
        sr.sprite = condition[randHeatlh-1];
    }

    public void resetBrick()
    {
        this.gameObject.SetActive(true);
        health = condition.Length;
        sr.sprite = condition[health - 1];
    }

    //private void canDrop()
    //{
        
    //}

    private void brickHit()
    {
        health--;

        if(health<= 0)
        {
            this.gameObject.SetActive(false);
        }
        else sr.sprite = condition[health - 1];

        FindObjectOfType<GameManager>().onBrickHit(this);
    }
}

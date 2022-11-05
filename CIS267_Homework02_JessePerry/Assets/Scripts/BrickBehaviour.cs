using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public int health { get; set;}
    public GameObject flipMovementPowerup;
    public GameObject addPuckPowerup;
    public GameObject rapidFirePowerup;
    public SpriteRenderer sr { get; set; }
    public BrickBehaviour[] brick;
    public Sprite[] condition;
    public int points = 1000;
    private int randHeatlh;
    public bool isTierThree;
    public bool isTierFive;


    //public bool canDrop;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        resetBrick();
        generateRandomHealth();
        tierChecker();
    }

    public void tierChecker()
    {
        if (health >= 4)
        {
            isTierFive = true;
        } else if (health >= 3)
        {
            isTierThree = true;
            return;
        } else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puck")
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

    private void brickHit()
    {
        health--;

        if(health<= 0)
        {
            int rng = Random.Range(1, 15);
            this.gameObject.SetActive(false);
            if (isTierFive && rng == 7)
            {
                Instantiate(rapidFirePowerup, this.transform.position, this.transform.rotation);
            }
            if(isTierThree && rng >= 12)
            {
                Instantiate(addPuckPowerup, this.transform.position, this.transform.rotation);
            }
            if(!isTierThree && !isTierFive && rng >=12)
            {
                Instantiate(flipMovementPowerup, this.transform.position, this.transform.rotation);
            }

        }
        else sr.sprite = condition[health - 1];

        FindObjectOfType<GameManager>().onBrickHit(this);
    }
}

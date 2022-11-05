using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehaviour : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public float speed;
    private bool addSpeedActive;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        resetPuck();
    }

    public void resetPuck()
    {
        Debug.Log("wooooahahahh");
        this.transform.position = Vector2.zero;
        this.rb.velocity = Vector2.zero;

        speed = 15;

        addSpeedActive = false;
        Invoke("setDirection", 1);
    }

    private void LateUpdate()
    {
        rb.velocity = speed * (rb.velocity.normalized);

        if(!addSpeedActive)
        {
            addSpeedActive = true;
            Invoke("addSpeed", 15);
        }
    }

    private void addSpeed()
    {
        speed++;
        addSpeedActive = false;
        Debug.Log(speed);
    }

    private void setDirection()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rb.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBorder")
        {
            resetPuck();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryPuckBehaviour : MonoBehaviour
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
        Invoke("deletePuck", 15);
    }

    private void LateUpdate()
    {
        rb.velocity = speed * (rb.velocity.normalized);

        if (!addSpeedActive)
        {
            addSpeedActive = true;
            Invoke("addSpeed", 15);
        }
    }
    public void resetPuck()
    {
        addSpeedActive = false;
        setDirection();
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
        force.x = Random.Range(-.2f, .2f);
        force.y = 1;

        rb.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBorder")
        {
            deletePuck();
        }
    }

    private void deletePuck()
    {
        Destroy(this.gameObject);
    }
}


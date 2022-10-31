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
        addSpeedActive = false;
        Invoke("setDirection", 1);
    }

    private void LateUpdate()
    {
        rb.velocity = speed * (rb.velocity.normalized);

        if(!addSpeedActive)
        {
            addSpeedActive = true;
            Invoke("addSpeed", 10);
        }
    }

    private void addSpeed()
    {
        speed++;
        resetDelay();
        Debug.Log(speed);
    }

    private void resetDelay()
    {
        addSpeedActive = false;
    }

    private void setDirection()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rb.AddForce(force);
    }

}

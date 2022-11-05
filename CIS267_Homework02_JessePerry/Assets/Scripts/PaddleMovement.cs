using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public Vector2 direction { get; set; }
    public float speed;
    public float bAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void resetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (FindObjectOfType<GameManager>().isFlipped)
            {
                direction = Vector2.right;
            } else
            {
                direction = Vector2.left;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (FindObjectOfType<GameManager>().isFlipped) 
            {
                direction = Vector2.left;
            }
            else
            {
                direction = Vector2.right;
            }
        } else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.AddForce(direction * speed);
        }
    }


    //this was used to have the ball have fluid contact, meaning if hit on the left side of the paddle, the ball moves left & vice versa
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PuckBehaviour puck = collision.gameObject.GetComponent<PuckBehaviour>();

        if(puck != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            //?
            float width = collision.otherCollider.bounds.size.x / 2;

            float curAngle = Vector2.SignedAngle(Vector2.up, puck.rb.velocity);
            float bounceAngle = (offset / width) * bAngle;
            float newAngle = Mathf.Clamp(curAngle + bounceAngle, -bAngle, bAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            puck.rb.velocity = rotation * Vector2.up * puck.rb.velocity.magnitude;
        }
    }
}

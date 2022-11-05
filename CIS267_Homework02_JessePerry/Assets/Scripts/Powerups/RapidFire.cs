using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
            if (collision.gameObject.CompareTag("Paddle"))
            {
                FindObjectOfType<GameManager>().isRapid = true;
                FindObjectOfType<GameManager>().invokeReverseRapid();
            }
        }
    }
}

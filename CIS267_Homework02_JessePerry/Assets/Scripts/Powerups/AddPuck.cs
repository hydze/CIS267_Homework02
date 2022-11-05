using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPuck : MonoBehaviour
{
    public GameObject puck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
            if (collision.gameObject.CompareTag("Paddle"))
            {
                Instantiate(puck);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Puck")
        {
            FindObjectOfType<GameManager>().onBorderHit();
        }
    }
}

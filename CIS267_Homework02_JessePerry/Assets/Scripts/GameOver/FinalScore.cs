using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Awake()
    {
        scoreText.text = FindObjectOfType<GameManager>().scoreString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNewPuck : MonoBehaviour
{
    public GameObject puck;

    private void Start()
    {
        addPuck();
    }

    private void addPuck()
    {
        Instantiate(puck);
        Invoke("_addPuck", 5);
    }

    private void _addPuck()
    {
        Instantiate(puck);
        Invoke("addPuck", 5);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{


    private void OnMouseDown()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("01a Start");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("03b Lose");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject parent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        myCamera = Camera.main;
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 spawnPosition2D = SnapToGrid(CalculateWorldPointOfMouseClick());
        int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;
        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(spawnPosition2D);
        }
        else
        {
            Debug.Log("NOT ENOUGH MONEY");
        }
    }

    private void SpawnDefender(Vector2 spawnPosition2D)
    {
        if (!Button.selectedDefender) return;
        GameObject defender = Instantiate(Button.selectedDefender, spawnPosition2D, Quaternion.identity) as GameObject;
        defender.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 screenWorldSpace = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(screenWorldSpace);

        return worldPos;
    }
}

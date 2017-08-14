using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private Button[] buttonArray;

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {

        buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        Debug.Log(name + "Pressed");

        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }
}

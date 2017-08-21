using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    // Currently used as a tag
    public int starCost = 5;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }


    public void MakeStars(int stars)
    {
        starDisplay.AddStars(stars);
    }

}
 
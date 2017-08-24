using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 30;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private GameObject winLabel;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        FindWinLabel();
        winLabel.SetActive(false);
    }

    private void FindWinLabel()
    {
        winLabel = GameObject.Find("Win Label");
        if (!winLabel)
        {
            Debug.LogWarning("No Win Label Object");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void LoadNextLevel()
    {
        FindObjectOfType<LevelManager>().LoadNextLevel();
    }

    private void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }
}

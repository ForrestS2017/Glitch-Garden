using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusicChangeArray;

    private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        AudioClip curSceneAudio = LevelMusicChangeArray[scene.buildIndex];

        if (curSceneAudio)
        {
            Debug.Log("Playing clip: " + LevelMusicChangeArray[scene.buildIndex]);
            audioSource.clip = curSceneAudio;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

}

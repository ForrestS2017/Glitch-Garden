using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public float SecondsToLoadnextLevel;

    void Start()
    {
        if(SecondsToLoadnextLevel <= 0)
        {
            Debug.Log("Leve auto load disabled");
        }
        else
        {
            Invoke("LoadNextLevel", SecondsToLoadnextLevel);
        }
    }

	public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }
	
    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

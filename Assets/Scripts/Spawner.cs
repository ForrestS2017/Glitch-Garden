using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] AttackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in AttackerPrefabArray)
        {
            if(isTimeToSpawn(attacker))
            {
                SpawnAttacker(attacker);
            }
        }
	}

    void SpawnAttacker(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;

    }

    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        float spawnRateSeconds = attackerGameObject.GetComponent<Attacker>().spawnRateSeconds;
        float spawnsPerSecond = 1 / spawnRateSeconds;

        if(Time.deltaTime > spawnsPerSecond)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        if(Random.value < threshold)
        {
            return true;
        }

        return false;
    }
}

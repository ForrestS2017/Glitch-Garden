using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner currentLaneSapwner;


    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetCurrentLaneSpawner();
    }

    private void Update()
    {
        Debug.Log(gameObject.name + " is " + IsAttackerAheadInLane());
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
            
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // Look through all spawners and set currentLaneSapwner if found
    void SetCurrentLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
                currentLaneSapwner = spawner;
            return;
        }
        Debug.LogError(name + "Cannot find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        //Exit if no attackers
        if(currentLaneSapwner.transform.childCount <= 0)
        {
            return false;
        }
        // If there are attackers ahead of us
        foreach(Transform attacker in currentLaneSapwner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        //If there are attackers behind us
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}

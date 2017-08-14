using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float WalkSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter: " + collision.name);
    }

    public void SetSpeed(float speed)
    {
        WalkSpeed = speed;
    }

    // Called from the animator at the time of actual attack
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }


    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}

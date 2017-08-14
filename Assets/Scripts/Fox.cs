﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {

        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("Jump Trigger");
            Debug.Log("JUMP");
        }
        else
        {
            animator.SetBool("isAttacking",true);
            attacker.Attack(obj);
        }
        Debug.Log("Fox collided with " + collider);
    }

   
}
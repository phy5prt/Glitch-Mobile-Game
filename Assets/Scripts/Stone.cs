﻿using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

private Animator anim;
	// Use this for initialization
	void Start () {

	anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D enemy){

		if(enemy.GetComponent<Attacker>()){

		anim.SetTrigger("underAttack trigger");

		}


		}


}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this you can put in to check that when you make something and it needs two scripts that the second is present

[RequireComponent (typeof (Attacker))]

public class Fox : MonoBehaviour {


private Animator anim;
private Attacker attacker;
private GameObject objInst;
//private Collider2D collider;


	// Use this for initialization
	void Start () {

	attacker = GetComponent<Attacker>();
	anim = GetComponent<Animator>();
	//	attacker = FindObjectOfType<Attacker>();
	}



	// Update is called once per frame
	void Update () {


	
	}






	void OnTriggerEnter2D(Collider2D enemy){
	//collider = GetComponent<Collider2D>();
	objInst = enemy.gameObject;

	//abort if not colliding with defender
	if (!objInst.GetComponent<Defender>()){
	//		Debug.Log("I am" +gameObject + "ObjInst isn't a Defender its an " +objInst);

	return;}

	//below better than mine because check for scripts in compile time and when i used the obj name instead of tag when i used multiple it renamed the object (1) (2) etc
	//so name didnt stay the same



	if (objInst.GetComponent<Stone>()){anim.SetTrigger("isJumping");
		
		}else{

			//attacker.AttackThis(objInst);

			attacker.AttackThis(enemy.gameObject);
			anim.SetBool("isAttacking", true);

		


	}

	}

	//my version worked hidden
	//public void OnTriggerEnter2D(Collider2D defender){

	//Debug.Log("Fox Trigger now to if");

//	string defenderType = defender.gameObject.name;

//	Debug.Log("GraveStone is called " + defenderType);

		//if (defenderType == "GraveStone"){

//	Debug.Log("if statment triggered");


			//Animator animator = gameObject.GetComponent<Animator>();

		//	animator.SetBool("isJumping", true);


	}

using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {






private Animator anim;
private Attacker attacker;

	// Use this for initialization
	void Start () {

	anim = GetComponent<Animator>();
	attacker = GetComponent<Attacker>();
		//attacker = FindObjectOfType<Attacker>();

	}



	// Update is called once per frame
	void Update () {





	
	}

	void OnTriggerEnter2D(Collider2D collider){

	//grabs the actual gravestone
	GameObject obj = collider.gameObject;


	//abort if not colliding with defender
	if (!obj.GetComponent<Defender>()){
	return;
	}

	//put annim set bool

	attacker.AttackThis(obj);
	anim.SetBool("isAttacking", true);



	}

	}




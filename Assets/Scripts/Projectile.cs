using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

public float speed;
public float damage;
private GameObject attacker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	transform.Translate(Vector3.right*speed*Time.deltaTime);
	
	}

	void OnTriggerEnter2D(Collider2D col){

	//I've coded it different look at handling projectile damage 1:57 if problems


	//if (!col.GetComponent<Attacker>()){	return;	}else{


	//making my code match course
//			Attacker attacker = col.GetComponent<Attacker>();

			Attacker attacker = col.gameObject.GetComponent<Attacker>();
			Health health = col.gameObject.GetComponent<Health>();


			if (attacker && health){
			health.DealDamage(damage);

		//	Debug.Log("I am" + gameObject + "current target " + attacker + " damage " + damage);

//Debug.Log("projectile striking " + col.gameObject + " with " + damage + " damage" );
			//attacker.StrikeCurrentTarget(damage);
			Destroy(gameObject);
	}



	}

}

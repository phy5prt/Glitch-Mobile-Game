using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {



	// Use this for initialization
	public float health;



	public void DealDamage (float damage){

	health -= damage;

	if(health<=0){

	//optionally trigger animation of death

	DestroyObject();

	}
	//make method so can call in animator

	}

	public void DestroyObject(){

//	Debug.Log("Im trying to destroy myself " + gameObject);

	Destroy(gameObject);
	}
}

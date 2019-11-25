using UnityEngine;
using System.Collections;


//[RequireComponent(typeof(Rigidbody2D))]

public class Attacker : MonoBehaviour {


[Tooltip("Average number of seconds between appearances per lane")]
public float seenEverySeconds;

private float currentSpeed;
private Animator anim;
private GameObject currentTarget;

private GameObject objInst;


void Start(){
		anim = GetComponent<Animator>();

}
	
	// Update is called once per frame
	void Update () {


	//delete later just testing a static from button script
	//Debug.Log(Button.selectedDefender);

	transform.Translate(Vector3.left*currentSpeed*Time.deltaTime);

	//this mucking up code stops fox attacking need to know why it loses current Target
	//also issue that current target is not reverting back to itself
	//could use this

	if(!this.currentTarget){ 
		anim.SetBool("isAttacking", false);

		}


	}




	public void SetSpeed (float speed) {
	currentSpeed = speed;
	}



	public void StrikeCurrentTarget(float damage){

		//just got rid of ifs for now see if theyre the problem
		if (this.currentTarget){
	
					Health targetHealth = this.currentTarget.GetComponent<Health>();
					if(targetHealth){
	
									targetHealth.DealDamage(damage);
//									Debug.Log("I am" + gameObject + "current target " + this.currentTarget + " damage " + damage);
			}
//	********		so either the projectile is picking up the lizards damage or the lizard is picking up the projectile/cactuses target - when attack gravestone which isnt attacking doesnt get itself
//okay so lizard sets its target then attacking to true this loops in animator until the thing is dead but when it is hit by a projectile it then targets itself so fix is 
//it must only loop once through its attack and then have its collider retriggered or it should check its collider when it is doing the strike however this would mean it would
//do damage to the thing touching its collider when a projectile tells it to damage itself. alternatively a better method would request target and damge together. 			
		}



	}

	public void AttackThis(GameObject objInst){

	this.currentTarget = objInst;
	
	}


}

	//sets the attack animation
	//in my code which worked I just did it in its specific script wonder why this is better?

using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

public GameObject projectile, gun;
private GameObject projectileParent;
private Animator animator;
private Spawner myLaneSpawner;

//projectparent is gun dont get it ... ah actually parenting it elsewhere so not destroyed when enemy destroyed but still flies till gets to the shredder

void Start(){


animator = GetComponent<Animator>();


// create a parent if necessary
projectileParent = GameObject.Find("Projectiles");
if(!projectileParent){
projectileParent = new GameObject("Projectiles");
}




SetMyLaneSpawner();


}

void Update(){

if (IsAttackerAheadInLane()){
animator.SetBool("isAttacking", true);
}else{
animator.SetBool("isAttacking", false);



}

}

bool IsAttackerAheadInLane(){

//exit if no attackers in lane

if (myLaneSpawner.transform.childCount<=0){
return false;}

//if we find attackers are they ahead/


//transforms are funny you loop through at transform it automatically looks through its children but how do it otherwise, do you create array of children equal children in gameobject
//child is an attacker
foreach (Transform attacker in myLaneSpawner.transform){
if(attacker.transform.position.x>= transform.position.x){return true;
							}
					}
					//attackers in lane but behind
					return false;
	}
//look through all spawner and set my lane spawner

 void SetMyLaneSpawner(){
Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

foreach (Spawner spawner in spawnerArray){

if(spawner.transform.position.y == transform.position.y){
myLaneSpawner = spawner;
return;
}


}
		Debug.LogError(name + " can't find spawner in lane");



}

private void Fire(){

GameObject newProjectile = Instantiate(projectile);
newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;


//this worked but course asks you to put it to gun
//newProjectile.transform.position = projectileParent.transform.position;


}
}

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

public GameObject[] attackerPrefabArray;
public static float roughAdjustmentAllSpawnRates = 1f;
private float difficulty;
private float numberOfLanes = 5f;
public static bool difficultyUpdatedThisLevel;



	private float difficultySpawnIncrement;

void Start(){
		difficulty = PlayersPrefsManager.GetDifficulty();

if (difficulty > 2f && difficultyUpdatedThisLevel == false){

roughAdjustmentAllSpawnRates += UptheDifficulty();
Debug.Log("have I upped the initial roughadjustment " + roughAdjustmentAllSpawnRates);
difficultyUpdatedThisLevel = true;


}
}
/* works wanted to try something else
private void UptheDifficulty(){

//gets called every time there is a spawner
//want the first to do it for all of them


//I want each lane to increase rate from 0 to 2% this is 10% increase over all so may be a bit nasty


float increaseToLaneDifficulty = ((difficulty -  2f) /10f);
roughAdjustmentAllSpawnRates = 1 + increaseToLaneDifficulty;
//Debug.Log("Starting release rate increased to " + roughAdjustmentAllSpawnRates + " on top of all later changes");
difficultyUpdatedThisLevel = true;

}
*/	
public float UptheDifficulty(){

		difficulty = PlayersPrefsManager.GetDifficulty();

//cant get defender spawner to call this method

//I want each lane to increase rate from 0 to 2% this is 10% increase over all so may be a bit nasty
		if (difficulty > 2f){


			float difficultySpawnIncrement = ((difficulty -  2f) /10f);

//Debug.Log("Starting release rate increased to " + roughAdjustmentAllSpawnRates + " on top of all later changes");

//Debug.Log("Spawner says the difficulty is " + difficulty + " and is returning " + difficultySpawnIncrement);
return difficultySpawnIncrement;
}else{
//			Debug.Log("Spawner says the difficulty is " + difficulty + " and is returning " + 0f);

return 0f;}
}


	
	// Update is called once per frame
	void Update () {

	foreach(GameObject thisAttacker in attackerPrefabArray){
		if(isTimeToSpawn(thisAttacker)){
		Spawn(thisAttacker);

				}

	}

	}

	// to improve the code the spawner should set the rate at which each thing in array spawns not the attacker prefab
	//here I've introduced a rough spawner increase which just multiplies the existing rates on the prefab
	//later i should make each prefab come with a slider 0 to 1 for rate 
	//also with the ability to randomly switch between spawners in defender script and increase one of the spawners rates

	bool isTimeToSpawn(GameObject attackerGameObject){

	Attacker attacker = attackerGameObject.GetComponent<Attacker>();
	float meanSpawnDelay = attacker.seenEverySeconds;
	float spawnsPerSecond= 1/meanSpawnDelay;



	if(Time.deltaTime*spawnsPerSecond > Random.value){

	//something supposed to be here?

				//Debug.LogWarning("Spawn rate capped by frame rate");


	}


	//number of lanes is only in there because on the attacker it says how often the attack is being called, but as there
	//is a spawner per lane calling the attackers script in the scene the how many time you see a fox for example persecond
	//is 5 times as much ... equally could just rename the float on attacker spawnsPerSecondPerSpawner or per lane



	/* works but following is neater
	float threshold = spawnsPerSecond*Time.deltaTime/numberOfLanes;
	if(Random.value < threshold){
	return true;} else { return false; }
	*/

		float threshold = spawnsPerSecond*Time.deltaTime/numberOfLanes;
		threshold = threshold*roughAdjustmentAllSpawnRates;
		return (Random.value < threshold);

	}


	void Spawn (GameObject myGameObject){
	GameObject myAttacker = Instantiate(myGameObject) as GameObject;
	myAttacker.transform.parent = this.gameObject.transform;
	myAttacker.transform.position = this.gameObject.transform.position;
}





}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

private LevelManager levelManager;

	// Use this for initialization
	void Start () {

	levelManager = GameObject.FindObjectOfType<LevelManager>();

	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D(){
	//reseting the static just incase
		Spawner.roughAdjustmentAllSpawnRates = 1f;

string thisLevel = SceneManager.GetActiveScene().name;
PlayersPrefsManager.SetLastLevel(thisLevel);

levelManager.LoadLevel("03b_Lose");

	}




	}


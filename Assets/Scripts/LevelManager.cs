using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class LevelManager : MonoBehaviour {

//do i need something so it persists like 

	


void Start(){


		if(0 == SceneManager.GetActiveScene().buildIndex){


//changes to zero if i use a public float instead of  a number

		Invoke("LoadNextLevel", 3f);

		}

		/* 
		if (instance != null && instance != this) {
			Destroy (gameObject);
			// print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
				}
		*/


}

public void LoadLevelbyLevelNumber(int levelNumber){

int indexNumber = levelNumber +1;

//Debug.Log(" Scene manager was given level number " + levelNumber + " converted it to build order number " + indexNumber + "and is going to load it");

		SceneManager.LoadScene(indexNumber);
		resetStatics();
	//if levelmanager not persist this may not happen
//	Debug.Log("I reset statics following loading a level");

}


	public void LoadLevel(string name){


//		Debug.Log ("New Level load: " + name);
	
		SceneManager.LoadScene(name);
		resetStatics();
	//if levelmanager not persist this may not happen
//	Debug.Log("I reset statics following loading a level");
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Debug.Log ("Next Level load: " + (SceneManager.GetActiveScene().buildIndex + 1));
		resetStatics();
	//if levelmanager not persist this may not happen
	//Debug.Log("I reset statics following loading a level");
	}
	

	public void LoadLastLevel(){
	string lastLevel;
	lastLevel = PlayersPrefsManager.GetLastLevel();
	SceneManager.LoadScene(lastLevel);
	resetStatics();
	//if levelmanager not persist this may not happen
	//Debug.Log("I reset statics following loading a level");
	}

	private void resetStatics(){
//want this to be the first thing that happens on loading as both in spawner maybe a mini script in the parent as assume that is loaded first.

	Spawner.difficultyUpdatedThisLevel = false;
	Spawner.roughAdjustmentAllSpawnRates = 1f;
	}
	}


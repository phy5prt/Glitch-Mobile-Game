using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayersPrefsManager : MonoBehaviour {

const string MASTER_VOLUME_KEY = "master_volume";


//using float but dont think going to allow gradual increase?
const string DIFFICULTY_KEY = "difficulty";
const string LEVEL_KEY = "level_unlocked_";
const string LAST_LEVEL = "last_level_played";
//should i run all these on start up otherwise they not active till access options screen

public static void SetLastLevel(string Lastlevel)
{PlayerPrefs.SetString(LAST_LEVEL, Lastlevel);

}

public static string GetLastLevel(){
return PlayerPrefs.GetString(LAST_LEVEL);
}


	public static void SetMasterVolume(float volume){
	if (volume >= 0f && volume <=1f){
	PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
	}else {

	Debug.LogError("Master volume out of range");
	}
	}

	public static float GetMasterVolume(){
	return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}



	public static void Unlocklevel(int level){

	if (level<= SceneManager.sceneCountInBuildSettings ) 

	{
	PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);         // Use 1 for true as player prefs cant take bool
//	Debug.Log( "I am players prefs I unlocked level index " + level);

				 }else {
		Debug.LogError("Trying to unlock level not in build order");
		}

		}


		// to use this should do another screen go to level, button becomes active once been part level 1 and allows you to access the levels

		public static bool IsLevelUnlocked(int buildLevel){

		//+ not comma?

		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + buildLevel.ToString());

		//Debug.Log(" checking " + buildLevel + " to see if it has value 1 it has " + levelValue); 

		bool isLevelUnlocked = (levelValue==1);

		if (buildLevel<= SceneManager.sceneCountInBuildSettings) {
	    return isLevelUnlocked;

		} else{
		//Debug.LogError("Trying to query level not in build order");
		return false; 
		}
		}


		public static void SetDifficulty(float difficulty){

		if (difficulty <= 3f && difficulty >= 1f){
		PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
	//	Debug.Log("PPM just set difficulty to " + difficulty);


		}else{
		Debug.LogError("Difficult level does not exist");





		}
		}


		public static float GetDifficulty(){

	//	Debug.Log("ppm was just asked the difficulty i said " + PlayerPrefs.GetFloat(DIFFICULTY_KEY) );

		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);









		}
	}



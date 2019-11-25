using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

private int indexCheck;
private AudioSource audioSource;

public AudioClip[] levelMusicChangeArray;


	
	// Update is called once per frame
	void Awake () {
	DontDestroyOnLoad (gameObject);
	}


	void Start() {

	audioSource = GetComponent<AudioSource>();
	//added below because course but think already solved it
	//	audioSource.volume = PlayersPrefsManager.GetMasterVolume();

	}

	void OnLevelWasLoaded(int level){

	AudioClip thisLevelMusic = levelMusicChangeArray[level];


	Debug.Log("Playing clip" + levelMusicChangeArray[level]);



	if(thisLevelMusic){

	// i made below up does it work cant tell without deleting playerprefs
	//im setting on initialisation of the music the music to the volume previously set and if it has never been set to a default

	//need to add one to the start button in start menu to initiallise difficults as default or preset too

			//if ( PlayersPrefsManager.GetMasterVolume() != null) 

			//float hasAMasterVolumeBeenAsigned = PlayersPrefsManager.GetMasterVolume();
			//if ( hasAMasterVolumeBeenAsigned != null){

			//if ( PlayersPrefsManager.GetMasterVolume() != nul 3f){

			if ( PlayersPrefsManager.GetMasterVolume() != null){


			audioSource.volume = PlayersPrefsManager.GetMasterVolume();}


			else{audioSource.volume = 0.5f;}


	audioSource.clip = thisLevelMusic;
	audioSource.loop = true;
	audioSource.Play();
	}




	/*my attempt
	int thisLevel = SceneManager.GetActiveScene().buildIndex;

	if (indexCheck != thisLevel){
	indexCheck = thisLevel;
	AudioSource music = levelMusicChangeArray[indexCheck];
	music.Play();}

	*/

	}

	public void SetVolume(float volume){

	audioSource.volume = volume;

	}
}

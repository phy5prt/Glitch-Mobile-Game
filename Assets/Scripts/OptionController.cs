using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionController : MonoBehaviour {

public Slider volumeSlider;
public Slider difficultySlider;
public LevelManager levelManager;
private MusicManager musicManager;


	// Use this for initialization
	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayersPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayersPrefsManager.GetDifficulty();





	}
	
	// Update is called once per frame
	void Update () {

	musicManager.SetVolume(volumeSlider.value);
//	Debug.Log("OC set difficulty to " + difficultySlider.value);


	PlayersPrefsManager.SetDifficulty(difficultySlider.value);
	Debug.Log("OC set difficulty to " + difficultySlider.value);


	}

	public void SaveAndExit(){

	//not seem to save between plays on the test in unity wonder if will work when build it

	PlayersPrefsManager.SetMasterVolume(volumeSlider.value);
	PlayersPrefsManager.SetDifficulty(difficultySlider.value);

	levelManager.LoadLevel("Start Menu");

	}
	public void SetDefaults(){

	volumeSlider.value= 0.8f;
	difficultySlider.value = 2f;

	//could add a wipe for unlocked levels


	}
}

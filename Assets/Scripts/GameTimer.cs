using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameTimer : MonoBehaviour {

//public float startTime = 1f;
//private float timeLeft = 1f;
public float levelSeconds = 100; 
private AudioSource audioSource;
private bool isEndOfLevel = false;
private Slider slider;
private LevelManager levelManager;
private GameObject winLabel;

	// Use this for initialization
	void Start () {



	slider = GetComponent<Slider>();
	audioSource = GetComponent<AudioSource>();
	levelManager = GameObject.FindObjectOfType<LevelManager>();

	int thisLevel = SceneManager.GetActiveScene().buildIndex;
//	Debug.Log("this is level " + SceneManager.GetActiveScene().name + " index " + SceneManager.GetActiveScene().buildIndex + " Im unlocking " + thisLevel);

	PlayersPrefsManager.Unlocklevel(thisLevel);


	FindYouWin ();
	winLabel.SetActive(false);





	//timeLeft = startTime;
	//UpdateSlider(timeLeft);


	}
	
	// Update is called once per frame
	void Update () {

	slider.value= (1 - Time.timeSinceLevelLoad/levelSeconds);

	if (Time.timeSinceLevelLoad>=levelSeconds && !isEndOfLevel){


	HandleWinCondition ();

	}


	//UpdateSlider(timeLeft);
	
	}

	void HandleWinCondition ()
	{

	//i like them persisting so can see it going wrong so doing this change as an exercise
	DestroyAllTaggedObject();

		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
		Spawner.roughAdjustmentAllSpawnRates = 1f;
	}

	private void DestroyAllTaggedObject(){

	//no forloop no pointing it in the direction of spawners and children
		GameObject[] arrayTaggedGameObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach( GameObject destroyMe in arrayTaggedGameObjects){
	Destroy(destroyMe);



	}




	}


	void FindYouWin ()
	{
		winLabel = GameObject.Find ("Win");
		if (!winLabel) {
			Debug.LogWarning ("please create you win object");
		}
	}

	void LoadNextLevel(){
	levelManager.LoadNextLevel();


	}
	}



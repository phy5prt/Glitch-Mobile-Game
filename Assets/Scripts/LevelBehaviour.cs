using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelBehaviour : MonoBehaviour {


private GameObject gameTimer;
	private Slider gameTimerSlider;
	private float gameTimerSliderValue;
	private float newSpawnfrequency;

	public float fractionWaitBeforeIncreaseSpawn = 0.5f;
	public float endMultipleOfSpawnRate = 3f;
	public GameObject spawnerGameObject;
	private Spawner spawner;
//private Spawner spawners;
//private GameObject spawnersParent;


	// Use this for initialization
	void Start () {

	// hmm brought in as gameobject so doesnt spawn enemies i only want to read off it
	//then accessed by making an instance of spawner
	//is this another issue script called spawner and gameobject is too
	spawner = spawnerGameObject.GetComponent<Spawner>();
//	spawner = GetComponent<Spawner>();


	// how do i make the variable change affect all Spawners do i use a for each
	//child of the defender
	//or make the variable a static
	// currently this only effects the first it finds

		//private Spawner spawners;
		//	spawners = Spawner.FindObjectOfType<Spawner>();

		//this code only catches one copy too
		//spawnersParent = GameObject.Find("Spawners");
		//spawners = spawnersParent.GetComponentInChildren<Spawner>();

	//spawners = Spawner.FindObjectOfType<Spawner>();


	gameTimer = GameObject.Find("Game Timer");
	gameTimerSlider = gameTimer.GetComponent<Slider>();





	}
	
	// Update is called once per frame
	void Update () {
		gameTimerSliderValue = gameTimerSlider.value;
	//game timer counts down as a value from 1 to 0 so is a percent
	//I want to wait till the time is half the way through then start increasing difficulty by spawnign from its rate to three times it

		if( 1f > gameTimerSliderValue && gameTimerSliderValue < (1-fractionWaitBeforeIncreaseSpawn)) {

		//



		//math not working right
		/*
		//should go from 0 to 1 - fractionWaitBeforeIncreaseSpawn
			float timeLeftFromStartInc = (gameTimerSliderValue-fractionWaitBeforeIncreaseSpawn);


			//should go from 0 to fractionWaitbeforeIncreaseSpawn


			//should go from 0 to 1
			float percentOfInc = timeLeftFromStartInc +

			//should go from 0 to 1
				*/
				float timeToIncOver = 1-fractionWaitBeforeIncreaseSpawn;


				//game ticks down not up!!
				float timePassed = 1- gameTimerSliderValue;


			float timeStartInc = fractionWaitBeforeIncreaseSpawn;

			float incProgressOverGivenTime = ((1-(timeStartInc/timePassed))/(timeToIncOver));


			//when it start should be at 1 ideally it should really be at the current roughAdjustment but then would need a second static
			//or will lose the original amount between runnings of the game or maybe just a public float but for now assuming all levels start
			//with roughAdjustment of 1

			float startAtOne = 1-1*incProgressOverGivenTime;

				newSpawnfrequency = startAtOne + endMultipleOfSpawnRate*incProgressOverGivenTime;

		
					//need spawner.upthedifficulty added on
			

			//what doesnt work is spawner = getComponent<Spawner>(); because one is spawner one is game object however i 
			//am putting spawner in as a gameobject to the ui not as a script because i only want to be able to call a method from it

			Spawner.roughAdjustmentAllSpawnRates = newSpawnfrequency + spawner.UptheDifficulty();



			//above returning 0 not 0.1


			//spawner.roughAdjustmentAllSpawnRates = newSpawnfrequency;
	}

	if( gameTimerSliderValue >= 1f){
			Spawner.roughAdjustmentAllSpawnRates = 1f;


	}

	}





	
	}


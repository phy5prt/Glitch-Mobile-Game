using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

public int OriginalstarCost = 100;

//i could not make it public and make defender spawner always pull from the update method
public int starCost = 100;

private StarDisplay starDisplay;

private float difficulty;

	// Use this for initialization
	void Start () {


	//difficult adjustment of gnomes and the stars
	//eh it is updating and remembering the changes to the public text box change!
	//but that is the only place the original number is stored
	//there isnt seperate defender scripts

	//starCost =	UpdateStarCost();

	

	starDisplay = GameObject.FindObjectOfType<StarDisplay>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void OnTriggerEnter2D(){

	//Debug.Log(name+ " trigger enter");
	//}


	//amimator which triggers the method can only trigger the method on the object it is on which is the defender so the defender method simply is there
	//to run the method in the display because animator cant trigger that method directly

	public void AddStars(int amount){
//print (amount);

starDisplay.AddStars(amount);
}

public int UpdateStarCost(){

	difficulty = PlayersPrefsManager.GetDifficulty();

	//does it need to return an int or just change the int ..?


		if (difficulty < 2f && this.OriginalstarCost > 45){
	
		float percentOriginal = difficulty/2f;

	Debug.Log("On easy so reducing to percent of original cost for expensive item " + percentOriginal);		

	this.starCost = (Mathf.RoundToInt((OriginalstarCost*percentOriginal)/5))*5;



	return starCost;
	} else{ 
//			Debug.Log("Not on easy so not reducing to percent of original cost for expensive item cost still " + starCost);
			starCost = OriginalstarCost;
	 return starCost;

	}
}
}

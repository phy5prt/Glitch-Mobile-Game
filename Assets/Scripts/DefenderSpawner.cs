using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;


//projectparent is gun dont get it ... ah actually parenting it elsewhere so not destroyed when enemy destroyed but still flies till gets to the shredder

void Start(){

defenderParent = GameObject.Find("Defenders");
starDisplay = GameObject.FindObjectOfType<StarDisplay>();
if(!defenderParent){
defenderParent = new GameObject("Defenders");
}
}

	void OnMouseDown(){

	//my code works but need to draw defenders first

	/*
	float gridX = snapToGrid(CalculateWorldPointOfMouseClick()).x;
	float gridY = snapToGrid(CalculateWorldPointOfMouseClick()).y;
	float gridZ = 10f;
	Vector3 instantiateHere = new Vector3(gridX, gridY, gridZ);

		Instantiate(Button.selectedDefender, instantiateHere, Quaternion.identity);

		*/


		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = snapToGrid(rawPos);
		GameObject defender = Buttons.selectedDefender;



		//shouldnt this throw up the issue of starCost not being altered or does running updatestarcost update starcost from the public console box
		//even if not returning it to own script ... previous i has code in start starCost = starCostUpdate(); but only use start when dropped i presumer
		//maybe should replace with UpdateStarCost but running it multiple times will keep forcing down the cost need to run only once per level. (due to the less than 40 bit in the if

		//this can throw up an issue if they dont start by clicking an object so could make it light up the object backgrounds for a second if nothing selected but
		//not too worried about it.

		int defenderCost = defender.GetComponent<Defender>().starCost;



		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
		SpawnDefender (roundedPos, defender);}else{
	//	Debug.Log("Insuficient stars to spawn");
	}
}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		GameObject newDef = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}

Vector2 snapToGrid(Vector2 rawWorldPos){


//my code truncates so if you click in the square you get the object in the square their code doesn't ... or i suppose it does as the centre of a square is actually
//the round number and the edges fall on the .5 they must of planned it that way as you will always be dropping to the middles.



/*
int newX = (int)rawWorldPos.x;
int newY = (int)rawWorldPos.y;
*/



		float newX =Mathf.RoundToInt(rawWorldPos.x);
		float newY =Mathf.RoundToInt(rawWorldPos.y);



return new Vector2(newX, newY);
}


	Vector2 CalculateWorldPointOfMouseClick(){

	float mouseX=Input.mousePosition.x;
	float mouseY=Input.mousePosition.y;
	float distanceFromCamera = 10f;

	Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
	Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
	return worldPos;

		/*float translationX =  (Input.mousePosition.x)/(1200f/9f);
		//-1.5f*(1200f/9f);
		float translationY =  (Input.mousePosition.y)/(675f/6f);
		//-1f*(675f/6f);

Vector2 worldPosition = new Vector2(translationX,translationY);
return worldPosition;

*/
}




	}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

private Text starText;
public int stars = 250;
private Color oldColor;
	private float starModifierPercent;
public enum Status {SUCCESS, FAILURE};

private float difficulty;
private float starsFloat;

	// Use this for initialization
	void Start () {

starText = GetComponent<Text>();
starText.text = stars.ToString();

DifficultyAdjustment();


UpdateDisplay();

}

private void DifficultyAdjustment(){

//altering star value

oldColor = 	starText.color;
Debug.Log("Stars unmodified " + stars);

starsFloat=stars;
difficulty = PlayersPrefsManager.GetDifficulty();
starModifierPercent = 0.2f - difficulty*0.1f;
starsFloat += starsFloat*starModifierPercent;

stars = (Mathf.RoundToInt(starsFloat/5))*5;

//stars = (Mathf.RoundToInt(starsFloat/10f))*10;
Debug.Log("Timer: difficulty = " +difficulty + " StarModifierPercent = " + starModifierPercent + " Starsfloat = " +starsFloat + " stars = " +stars);

// would be nice to reduce gnome and trophy cost but not sure how to find those objects as all dropped in two places one for cost one to make;


}	
	

public void AddStars(int amount){
	
	returnColor();
	stars += amount;

		UpdateDisplay();
	

	}

	public Status UseStars(int amount){

	if (stars>= amount){
		returnColor();
		stars -= amount;

		//will need an if statement for if goes below zero

		UpdateDisplay();
	return Status.SUCCESS;
	}

	// need it to flash red then turn back so an invoke

		starText.color = new Color(1,0,0,1);
		Invoke("returnColor",0.2f);
	return Status.FAILURE;
	}

	private void UpdateDisplay(){
		returnColor();
		starText.text = stars.ToString();

	}
	private void returnColor(){
		starText.color = oldColor;

	}
	}


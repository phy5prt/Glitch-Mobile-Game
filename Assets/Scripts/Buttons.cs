using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Buttons : MonoBehaviour {


private Buttons[] buttonArray;
public static GameObject selectedDefender;
public GameObject thisButtonsPrefab;
private Text costText;
//private int defendersStarCost;
//private Defender defender;

	// Use this for initialization
	void Start () {
 
	//defendersStarCost = defender.starCost;

	costText = this.gameObject.GetComponentInChildren<Text>();
	if(!costText){Debug.LogWarning(name + " has no cost ");}	

	//it is pulling the starCost from the prefab public console not where it is changed in code  

	costText.text = thisButtonsPrefab.GetComponent<Defender>().UpdateStarCost().ToString();


	//am i right in thinking they are of type button because they have the button script? - yep tested it that exactly right 
	//so find everything witht his script and then the foreach does stuff to it.
	buttonArray = GameObject.FindObjectsOfType<Buttons>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

	selectedDefender = thisButtonsPrefab;

	foreach(Buttons thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color= Color.black;
	}

	GetComponent<SpriteRenderer>().color= Color.white;


	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class availableLevels : MonoBehaviour {

private Text mytextLvlName;
private int levelNameInt;
private int buildLvlEquivalent;
private bool levelAvailable;
//private Selectable thisButton;

	// Use this for initialization

	private Button thisButton;
//private GameObject thisGameObject;

	private LevelManager levelManager;



	void Start () {


	///ahh still no idea why i can grab the button component
	//i have named a script button will try rename it


	thisButton = this.GetComponent<Button>();
	thisButton.interactable = false;

		levelManager = GameObject.FindObjectOfType<LevelManager>();



			//this.gameObject.SetActive(false);




//interactable would be better but cant seem to get hold of it




		



	//build order is one more than the level code
		//turning my text into code so dont need to rely on public variable, cutting string or using the name of this object or tag
	//may have to do above if start using level names

mytextLvlName = this.GetComponent<Text>();
levelNameInt = int.Parse(mytextLvlName.text);
buildLvlEquivalent = levelNameInt +1;

//Debug.Log("from available level ... my level button text is " + levelNameInt + " that is build equivalent " + buildLvlEquivalent);

levelAvailable = PlayersPrefsManager.IsLevelUnlocked(buildLvlEquivalent);

if(levelAvailable){
			thisButton.interactable = true;

}

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void loadMyLevel(){

		Debug.Log("from the text I am trying to load " + this.mytextLvlName);

	levelManager.LoadLevelbyLevelNumber(this.levelNameInt);

	}


}

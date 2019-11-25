using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {


private Text mytext;
private float myfloat;

	// Use this for initialization
	void Start () {

	mytext = GetComponent<Text>();
	mytext.text = "1f";
	
	}
	
	// Update is called once per frame
	void Update () {
	myfloat = float.Parse(mytext.text);
		Spawner.roughAdjustmentAllSpawnRates = myfloat;
	Debug.Log(Spawner.roughAdjustmentAllSpawnRates);


	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {


public float fadeInTime;
private Image fadePanel;
public Color currentColor;


	// Use this for initialization
	void Start () {
	fadePanel = GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.timeSinceLevelLoad < fadeInTime) {

	float alphaChange = Time.deltaTime/fadeInTime;

	currentColor.a -= alphaChange;
	fadePanel.color = currentColor;

	//currentColor = (1-(Time.timeSinceLevelLoad/fadeInTime))*255;
		//	Debug.Log(currentColor.a);

	} else{ 

		gameObject.SetActive(false);

		}
	}
}

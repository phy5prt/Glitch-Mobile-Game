﻿using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){


FindObjectOfType<LevelManager>().LoadLevel("Start Menu");

	}
}

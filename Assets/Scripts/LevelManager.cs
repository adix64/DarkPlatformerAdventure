using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	[SerializeField]
	public string songName = "Stairway";
	[SerializeField]
	public bool rainy = false;
	// Use this for initialization
	void Start () {
		GameObject.FindObjectOfType<AudioManager> ().StopAllMusic ();
		GameObject.FindObjectOfType<AudioManager> ().StopAllAmbient ();
		if (songName != "")
			GameObject.FindObjectOfType<AudioManager> ().Play (songName);
		GameObject.FindObjectOfType<AudioManager> ().Play ("ShepardTone");
		if(rainy)
			GameObject.FindObjectOfType<AudioManager> ().Play ("Rain");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

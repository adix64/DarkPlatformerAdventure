using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		
		if (col.gameObject.tag == "Player") {
			SceneManager.UnloadSceneAsync ("level1");
			SceneManager.LoadScene("level2");
			Debug.Log ("LOAD NEXT LEVEL");
		}
	}
}

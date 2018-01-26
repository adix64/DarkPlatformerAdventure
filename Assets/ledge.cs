using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ledge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("ledgeGrab");
	}

	// Update is called once per frame
	void Update () {
		
	}
}

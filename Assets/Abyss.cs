using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		AshController ashCtrl = col.gameObject.GetComponent<AshController> ();
		if (ashCtrl != null)
		{
			ashCtrl.ResetPosition ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}

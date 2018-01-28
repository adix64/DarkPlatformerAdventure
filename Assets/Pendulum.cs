using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

	float totalT = 0f;
	// Use this for initialization
	void Start () {
		transform.rotation = new Quaternion (0, 0, 1, 0);
		Debug.Log ("AMICRAZY");
	}
	
	// Update is called once per framea
	void FixedUpdate () {
		totalT += Time.fixedDeltaTime;
		//Debug.Log ("AMICRAZY");
		float fact = Mathf.Sin(Time.fixedTime);
		fact = Mathf.Sin (fact);
		gameObject.transform.rotation = Quaternion.Euler(0,0,60 * fact);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRotatable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler (0, 70 * Time.time, 0);
	}
}

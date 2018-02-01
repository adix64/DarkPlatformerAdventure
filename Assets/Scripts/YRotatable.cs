using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRotatable : MonoBehaviour {
	[SerializeField]
	public float phase = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Euler (0, 70 * Time.time + phase, 0);
	}
}

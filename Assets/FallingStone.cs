using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour {
	private Vector3 initialPos;
	private Rigidbody rb;
	public float lowerLimit = -10;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		initialPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < lowerLimit) {
			transform.position = initialPos;
			rb.velocity = new Vector3 (0, 0, 0);
		}
	}

}

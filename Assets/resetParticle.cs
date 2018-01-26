using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetParticle : MonoBehaviour {
	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ps.time > 1.0f) {
			ps.Simulate(0.0f, true, true);
			ps.time = 0.0f;
			ps.Play ();
		}
	}
}

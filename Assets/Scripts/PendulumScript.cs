using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour {
	float countDown = 0f;
	bool triggerStop = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggerStop)
		{
			if (countDown < 5.0f)
				countDown += Time.deltaTime;
			else {
			
				triggerStop = false;
				countDown = 0.0f;
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (!triggerStop && col.gameObject.tag == "Player")
		{
			triggerStop = true;
			col.gameObject.GetComponent<AshController> ().Die();
		}

	}
}

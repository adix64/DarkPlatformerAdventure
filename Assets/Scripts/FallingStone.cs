using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
	private Vector3 initialPos;
	private Rigidbody rb;
	public float lowerLimit = -10;
	[SerializeField] public bool isDeadly = false;
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

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && isDeadly)
        {
            col.gameObject.GetComponent<AshController>().Die();
        }

        if (col.gameObject.tag == "RockResetter")
		{
			transform.position = initialPos;
			rb.velocity = new Vector3 (0, 0, 0);
		}
	}
}

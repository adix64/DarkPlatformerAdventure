using UnityEngine;
using System.Collections;

public class followAsh : MonoBehaviour {
	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = character.transform.position.x;
		float y = Mathf.Max(-5f,character.transform.position.y);
		float z = this.transform.position.z;
		this.transform.position = new Vector3 (x, y, z);
	}
}

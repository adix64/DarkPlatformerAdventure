using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	Vector3[] chpPositions;
	int maxCheckpoint = 0;
	// Use this for initialization
	void Start () {
		chpPositions = new Vector3[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			chpPositions [i] = transform.GetChild(i).transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Register(Checkpoint chp)
	{
		Debug.Log ("Checkpoint reached" + chp.checkpointID);
		maxCheckpoint = Mathf.Max (maxCheckpoint, chp.checkpointID);
	}
	public Vector3 GetCheckpointPosition()
	{
		return chpPositions [maxCheckpoint];
	}
}

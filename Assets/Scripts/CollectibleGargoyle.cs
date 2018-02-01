using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGargoyle : MonoBehaviour {

	bool triggeredCollect = false;
	float scale = 1.0f;
	float inflateTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggeredCollect) {
			if (inflateTime < 1f)
				scale += Time.deltaTime;
			else
				scale -= 2f * Time.deltaTime;

			inflateTime += Time.deltaTime;
			scale = Mathf.Max (scale, 0f);
			transform.localScale = new Vector3 (scale,scale,scale);
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag != "Player")
			return;
		GetComponent<BoxCollider>().enabled = false;
		FindObjectOfType<AudioManager> ().Play ("CollectedGargoyle");
		triggeredCollect = true;
		transform.Find ("particles").gameObject.SetActive (true);
		StartCoroutine (Collect ());
	}

	IEnumerator Collect()
	{
		yield return new WaitForSeconds (3.0f);
		GameObject.FindWithTag("MainCamera").GetComponent<CollectiblesUI> ().AddCollectible ();
		Destroy(this.gameObject);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesUI : MonoBehaviour {
	int maxCollectibles = 3;
	int collectedItemsCount = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < maxCollectibles; i++)
			transform.Find("CGargoyle" + (i + 1).ToString()).gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetNumCollectibles(int n)
	{
		for (int i = 0; i < n; i++) 
			transform.Find("CGargoyle"+ (i + 1).ToString()).gameObject.SetActive(true);
		
		for (int i = n; i < maxCollectibles; i++)
			transform.Find("CGargoyle"+ (i + 1).ToString()).gameObject.SetActive(false);
	}

	public void AddCollectible()
	{
		collectedItemsCount++;
		SetNumCollectibles (collectedItemsCount);
	}
}

using UnityEngine;
using System.Collections;

public class RopeBitScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        

		ChrControl hull = other.gameObject.GetComponent<ChrControl>();
		if (hull != null && hull.activeRope == null)
        {
			Debug.Log("HAI IN BASCULANTA!");
            //Physics.IgnoreCollision(this.GetComponent<Collider>(), other.GetComponent<Collider>());
            hull.AttachToRope(this.gameObject);
        }
        //other.gameObject.transform.position = this.transform.position;
        //Destroy(other.gameObject);
    }

}

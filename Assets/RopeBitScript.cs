using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
public class RopeBitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HAI IN BASCULANTA!");

        ThirdPersonCharacter hull = other.gameObject.GetComponent<ThirdPersonCharacter>();
        if (hull != null)
        {
            //Physics.IgnoreCollision(this.GetComponent<Collider>(), other.GetComponent<Collider>());
            hull.AttachToRope(this.gameObject);
        }
        //other.gameObject.transform.position = this.transform.position;
        //Destroy(other.gameObject);
    }

}

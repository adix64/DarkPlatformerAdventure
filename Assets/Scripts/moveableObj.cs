using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class moveableObj : MonoBehaviour {

	ChrControl mChrCtrl = null;
	bool inContact = false;
	GameObject ash;
	Rigidbody mRigidBody, ashRigidBody;

	void Start ()
	{
		ash = GameObject.FindWithTag("Player");		
		mChrCtrl = ash.GetComponent<ChrControl> ();
		mRigidBody = gameObject.GetComponent<Rigidbody>();
		ashRigidBody = ash.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Vector3.Distance (ash.transform.position, transform.position) > 2.8f)
		{
			inContact = false;
		}
			
		if (inContact)
		{
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
			if (Input.GetKey (KeyCode.F))
			{
				mRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
				mChrCtrl.PushPullMode (true);
				mRigidBody.velocity = 2.0f * ashRigidBody.velocity;
			} else 
			{
				mRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				mChrCtrl.PushPullMode(false);
			}
		} else {
			mChrCtrl.PushPullMode(false);
			mRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
		}

	}

	void OnCollisionEnter(Collision collision)
	{
		ChrControl chrCtrl = collision.gameObject.GetComponent<ChrControl> ();
		if (chrCtrl != null)
		{
			inContact = true;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		ChrControl chrCtrl = collision.gameObject.GetComponent<ChrControl> ();
		if (chrCtrl != null && Vector3.Distance (ash.transform.position, transform.position) > 3f)
		{
			inContact = false;
		}
	}

}
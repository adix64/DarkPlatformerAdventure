using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class moveableObj : MonoBehaviour {
	ChrControl mChrCtrl = null;

	// Use this for initialization
	bool inContact = false;
	GameObject ash;
	Rigidbody mRigidBody, ashRigidBody;
	void Start ()
	{
		ash = GameObject.Find ("ThirdPersonController");		
		mChrCtrl = ash.GetComponent<ChrControl> ();
		//ashCtrl = tpc.GetComponent<AshController> ();
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY |RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
		mRigidBody = gameObject.GetComponent<Rigidbody>();
		ashRigidBody = ash.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Vector3.Distance (ash.transform.position, transform.position) > 2.8f)
		{
			inContact = false;
		}

		//mRigidBody.mass = 100.0f;
		if (inContact)
		{//Vector3.Distance (ash.transform.position, transform.position) < 2.05f) {
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
			if (Input.GetKey (KeyCode.F)) {
				mChrCtrl.PushPullMode (true);
				//mRigidBody.mass = 0.0f;

				mRigidBody.velocity = 2.0f * ashRigidBody.velocity;
			} else {
				mChrCtrl.PushPullMode(false);
			}
		} else {
			mChrCtrl.PushPullMode(false);
		}

	}


	void OnCollisionEnter(Collision collision)
	{
		
		Debug.Log("Box Touched");
		ChrControl chrCtrl = collision.gameObject.GetComponent<ChrControl> ();
		if (chrCtrl != null)
		{
			inContact = true;
	///		chrCtrl.PushPullMode(true);
		}

		//foreach (ContactPoint contact in collision.contacts)
		//{
		//	Debug.DrawRay(contact.point, contact.normal, Color.white);
		//}

	}

	void OnCollisionExit(Collision collision)
	{

		Debug.Log("Box Touched");
		ChrControl chrCtrl = collision.gameObject.GetComponent<ChrControl> ();
		if (chrCtrl != null && Vector3.Distance (ash.transform.position, transform.position) > 3f)
		{
			inContact = false;
			///		chrCtrl.PushPullMode(true);
		}

		//foreach (ContactPoint contact in collision.contacts)
		//{
		//	Debug.DrawRay(contact.point, contact.normal, Color.white);
		//}

	}

}
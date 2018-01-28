using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
[RequireComponent(typeof (ChrControl))]
public class AshController : MonoBehaviour
{
	private ChrControl m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

	bool canSwing = true;
	bool swinging = false;
	bool raising = false;
	Rigidbody player;
    private void Start()
    {
		player = gameObject.GetComponent<Rigidbody> ();
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ChrControl>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

    }

	private void LateUpdate()
	{


	}


	private void HandleRopeMovement(float h)
	{
		if(swinging == false){
			
			if (raising == true) {
				Debug.Log ("Spawnalagiw");
				player.velocity = new Vector3 (player.velocity.x + transform.forward.x * 0.1f, 10, 0);
			}
		}

		else{
			

			m_Character.m_IsGrounded = false;
			GetComponent<CapsuleCollider>().enabled = false;

			if(Mathf.Abs(h) > 0.1f){
				Debug.Log ("HAVE TO MOVE");
				Debug.Log (h);
				player.velocity =  (new Vector3(Mathf.Sign(h) * 10,player.velocity.y,0));
			}
				
			if(Input.GetButtonDown("Jump")){

				GetComponent<Animator> ().SetTrigger("ReleaseRope");
				player.velocity = new Vector3 (player.velocity.x + transform.forward.x * 0.1f, 10, 0);
				swinging = false;
				raising = true;
				Destroy(GetComponent<HingeJoint>());
				StartCoroutine(Wait());
			}
		}
	}
    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {

        // read inputs
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
		HandleRopeMovement (h);
        bool crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = h * m_Cam.right;// v*m_CamForward + h*m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v*Vector3.forward + h*Vector3.right;
        }
#if !MOBILE_INPUT
		// walk speed multiplier
        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

        // pass all parameters to the character control script
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
    }
	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.tag == "Rope" && canSwing == true) {
			GetComponent<CapsuleCollider> ().enabled = false;
//			player.position = other.gameObject.transform.position;
			player.transform.position = other.gameObject.transform.position + new Vector3 (0, -1, 0);
			GetComponent<Animator> ().SetTrigger ("HangOnRope");
			Debug.Log (other.gameObject.name);
			canSwing = false;
			swinging = true;
			HingeJoint hinge = gameObject.AddComponent<HingeJoint> () as HingeJoint;
			hinge.connectedBody = other.gameObject.GetComponent<Rigidbody> ();
			hinge.anchor = new Vector3 (0, 255, 0);
			hinge.axis = new Vector3 (0, 0, 1);
			hinge.connectedAnchor = new Vector3 (0, 0, 0);
		}
	}

	public IEnumerator ResetPosition (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Debug.Log ("DIED!!!!!");
		Vector3 respawnPosition = GameObject.Find ("Checkpoints").GetComponent<CheckpointManager> ().GetCheckpointPosition();
		gameObject.transform.position = respawnPosition;
		GetComponent<Animator> ().SetTrigger ("Revive");
		GetComponent<ChrControl>().m_IsGrounded = true;
		GetComponent<CapsuleCollider> ().height = 228.6f;

	
	}
	public void Die()
	{
		GetComponent<Animator> ().SetTrigger ("Die");
		GetComponent<CapsuleCollider>().height = 0.6f;
		StartCoroutine(ResetPosition(3f));
//		ResetPosition ();
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (0.15f);
		canSwing = true;
		GetComponent<CapsuleCollider>().enabled = true;
		raising = false;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody body;
	private bool dashGoing;
	private float playerRemainingDashDuration;
	private Vector3 dashVector;
	private Timer timer;
	private Vector3 force;
	public float movSpeed;
	public float jumpPower;

	public float dashDuration;
	public float dashMultiplier;
	public PlayerInput playerInput;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		playerRemainingDashDuration = dashDuration;
		timer = GameObject.Find ("Canvas").GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.GetPlayersCanMove ()) {
			Move (gameObject.tag, body);
		}
	}

	void Move(string player, Rigidbody b) {
		force = Vector3.zero;

		if (!dashGoing) {
			force = new Vector3 (playerInput.GetXInput (player), 0, playerInput.GetYInput (player)); 
			if (playerInput.GetJump (gameObject.tag) && GetComponent<GroundCheck>().GetIsGrounded()) {
				b.AddForce (new Vector3 (0, jumpPower, 0));
			}
			force = force.normalized * movSpeed * Time.deltaTime;
		} else {
			force = dashVector;
		}

		if (playerInput.GetDash (gameObject.tag) == true && !dashGoing) {
			dashVector = force * dashMultiplier;
			dashGoing = true;
		}
			
		if (dashGoing) {
			playerRemainingDashDuration = playerRemainingDashDuration - 0.1f;
			force = force * dashMultiplier;

			if (playerRemainingDashDuration <= 0) {
				dashGoing = false;
				playerRemainingDashDuration = dashDuration;
			}
		}
			
		force.y = b.velocity.y;
		b.velocity = force;

		if (force != Vector3.zero) {
			force = new Vector3 (force.x, 0, force.z);
			transform.rotation = Quaternion.LookRotation (force.normalized);
		}
	}

	public Vector3 getForce() {
		return force;
	}

	public bool getDashGoing() {
		return dashGoing;
	}
}

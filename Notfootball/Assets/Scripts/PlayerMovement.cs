using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody body;
	private bool dashGoing;
	private float playerRemainingDashDuration;
	private Vector3 dashVector;


	public float movSpeed;

	public float dashDuration;
	public float dashMultiplier;

	private Vector3 spawnPos;

	public PlayerInput playerInput;

	private Timer timer;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	
		playerRemainingDashDuration = dashDuration;
		spawnPos = transform.position;

		timer = GameObject.Find ("Canvas").GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.GetPlayersCanMove ()) {
			Move (gameObject.tag, body);
		}
	}

	void Move(string player, Rigidbody b) {
		Vector3 force = Vector3.zero;

		if (!dashGoing) {
			force = new Vector3 (playerInput.GetXInput (player), 0, playerInput.GetYInput (player)); 
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
	}

	void Spawn() {
		transform.position = spawnPos;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody body;
<<<<<<< HEAD
	private bool dashGoing;
	private float player2DashDuration;
	private Vector3 player2DashVector;


	public float movSpeed;

	public float dashDuration;
	public float dashMultiplier;

=======
	private Vector3 spawnPos;

	public float movSpeed;
>>>>>>> refs/remotes/origin/SimoBB
	public PlayerInput playerInput;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
<<<<<<< HEAD
	
		player2DashDuration = dashDuration;
=======
		spawnPos = transform.position;
>>>>>>> refs/remotes/origin/SimoBB
	}
	
	// Update is called once per frame
	void Update () {
		Move (gameObject.tag, body);
	}

<<<<<<< HEAD
		if (playerTag.Equals ("Player1")) {
			Vector3 force = Vector3.zero;
			/*
			if (Input.GetKey (KeyCode.A)) {
				force += Vector3.left;
				//transform.Translate (Vector3.left * movSpeed * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.W)) {
				force += Vector3.forward;
				//transform.Translate (Vector3.forward * movSpeed * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.D)) {
				force += Vector3.right;
				//transform.Translate (Vector3.right * movSpeed * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.S)) {
				force += Vector3.back;
				//transform.Translate (Vector3.back * movSpeed * Time.deltaTime);
			}
			*/

			force = new Vector3 (playerInput.GetXInput ("Player1"), 0, playerInput.GetYInput ("Player1")); 
			force = force.normalized * movSpeed * Time.deltaTime;

			force.y = body.velocity.y;
			body.velocity = force;
		}

		if (playerTag.Equals ("Player2")) {

			Vector3 force = Vector3.zero;

			if (!dashGoing) {

				if (Input.GetKey (KeyCode.LeftArrow)) {
					force += Vector3.left;
					//transform.Translate (Vector3.left * movSpeed * Time.deltaTime);
				}

				if (Input.GetKey (KeyCode.UpArrow)) {
					force += Vector3.forward;
					//transform.Translate (Vector3.forward * movSpeed * Time.deltaTime);
				}

				if (Input.GetKey (KeyCode.RightArrow)) {
					force += Vector3.right;
					//transform.Translate (Vector3.right * movSpeed * Time.deltaTime);
				}

				if (Input.GetKey (KeyCode.DownArrow)) {
					force += Vector3.back;
					//transform.Translate (Vector3.back * movSpeed * Time.deltaTime);
				}

				force = force.normalized * movSpeed * Time.deltaTime;


			} else {
				force = player2DashVector;
			}

			if (playerInput.GetDash ("Player2") == true && !dashGoing) {
				player2DashVector = force * dashMultiplier;
				print ("DASH");
				dashGoing = true;
			}

			if (dashGoing) {
				player2DashDuration = player2DashDuration - 0.1f;
				print ("Dash: " + player2DashDuration);
				force = force * dashMultiplier;

				if (player2DashDuration <= 0) {
					dashGoing = false;
					player2DashDuration = dashDuration;
				}
			}

			force.y = body.velocity.y;

			body.velocity = force;
		}
=======
	void Move(string player, Rigidbody b) {
		Vector3 force = Vector3.zero;
		force = new Vector3 (playerInput.GetXInput (player), 0, playerInput.GetYInput (player)); 
		force = force.normalized * movSpeed * Time.deltaTime;
		b.velocity = force;
	}

	void Spawn() {
		transform.position = spawnPos;
>>>>>>> refs/remotes/origin/SimoBB
	}
}

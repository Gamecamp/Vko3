using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private string playerTag;
	private Rigidbody body;

	public float movSpeed;

	public PlayerInput playerInput;

	// Use this for initialization
	void Start () {
		playerTag = gameObject.tag;
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

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
			body.velocity = force;
		}

		if (playerTag.Equals ("Player2")) {

			Vector3 force = Vector3.zero;

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
			body.velocity = force;
		}
	}
}

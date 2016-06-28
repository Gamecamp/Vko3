using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody body;
	private Vector3 spawnPos;

	public float movSpeed;
	public PlayerInput playerInput;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		spawnPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move (gameObject.tag, body);
	}

	void Move(string player, Rigidbody b) {
		Vector3 force = Vector3.zero;
		force = new Vector3 (playerInput.GetXInput (player), 0, playerInput.GetYInput (player)); 
		force = force.normalized * movSpeed * Time.deltaTime;
		b.velocity = force;
	}

	void Spawn() {
		transform.position = spawnPos;
	}
}

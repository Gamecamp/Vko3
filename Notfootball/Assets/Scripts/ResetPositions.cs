using UnityEngine;
using System.Collections;

public class ResetPositions : MonoBehaviour {

	private GameObject ball;
	private GameObject player1;
	private GameObject player2;

	public float ballX;
	public float player1X;
	public float player2X;
	public float globalY;
	public float globalZ;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		ResetPosition ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPosition() {
		ball.transform.position = new Vector3 (ballX, globalY, globalZ);
		player1.transform.position = new Vector3 (player1X, globalY, globalZ);
		player2.transform.position = new Vector3 (player2X, globalY, globalZ);

		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		player1.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		player1.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		player2.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		player2.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		player1.transform.rotation = Quaternion.LookRotation (new Vector3 (-1, 0, 0));
		player2.transform.rotation = Quaternion.LookRotation (new Vector3 (1, 0, 0));
	}
}

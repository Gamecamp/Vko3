using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	private float player1InputXAxis;
	private float player1InputYAxis;

	private float player2InputXAxis;
	private float player2InputYAxis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player1InputXAxis = Input.GetAxis ("Horizontal");
		player1InputYAxis = Input.GetAxis ("Vertical");

		player2InputXAxis = Input.GetAxis ("Horizontal2");
		player2InputYAxis = Input.GetAxis ("Vertical2");
	}

	public float GetXInput(string player) {
		float input = 0;

		if (player.Equals ("Player1")) {
			input = player1InputXAxis;
		} 

		if (player.Equals ("Player2")) {
			input = player2InputXAxis;
		}
		return input; 
	}

	public float GetYInput(string player) {
		float input = 0;

		if (player.Equals ("Player1")) {
			input = player1InputYAxis;
		} 

		if (player.Equals ("Player2")) {
			input = player2InputYAxis;
		}
		return input; 
	}
}

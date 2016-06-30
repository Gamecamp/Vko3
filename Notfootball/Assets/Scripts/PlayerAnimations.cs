using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
	private Animator myAnim;
	private PlayerMovement pMov;
	//private ScoreBoard sBoard;

	// Use this for initialization
	void Start () {
		myAnim = this.gameObject.GetComponent<Animator> ();
		pMov = this.gameObject.GetComponent<PlayerMovement> ();
		//sBoard = GameObject.Find ("GameManager").GetComponent<Scoreboard> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (pMov.getForce() != Vector3.zero) {
			myAnim.SetBool ("isRunning", true);
		} else {
			myAnim.SetBool ("isRunning", false);
		}

		if (pMov.getDashGoing ()) {
			myAnim.SetBool ("isDashing", true);
		} else {
			myAnim.SetBool ("isDashing", false);
		}

		/*
		if (sBoard.getJustScored ()) {
			myAnim.SetBool ("isCheering", true);
		} else {
			myAnim.SetBool ("isCheering", false);
		}
		*/
	}
}

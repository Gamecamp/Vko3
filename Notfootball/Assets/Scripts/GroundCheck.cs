using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private bool isGrounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Ground") {
			SetIsGrounded (true);
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Ground") {
			SetIsGrounded (false);
		}
	}

	public void SetIsGrounded(bool isGrounded) {
		this.isGrounded = isGrounded;
	}

	public bool GetIsGrounded() {
		return isGrounded;
	}
}

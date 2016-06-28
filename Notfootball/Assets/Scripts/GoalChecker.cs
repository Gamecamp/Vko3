using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Ball") {
			if (gameObject.tag == "GoalP1") {
				print ("blueTeamScore");

			}

			if (gameObject.tag == "GoalP2") {
				print ("redTeamScore");
			}
		}

		print ("blaa");
	}
}

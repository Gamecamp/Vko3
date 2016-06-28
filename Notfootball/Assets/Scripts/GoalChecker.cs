using UnityEngine;
using System.Collections;

public class GoalChecker : MonoBehaviour {

	Scoreboard score;

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("Canvas").GetComponent<Scoreboard> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Ball") {
			if (gameObject.tag == "GoalP1") {
				print ("blueTeamScore");
				score.BlueTeamScores();

			}

			if (gameObject.tag == "GoalP2") {
				print ("redTeamScore");
				score.RedTeamScores();

			}
		}

		print ("blaa");
	}
}

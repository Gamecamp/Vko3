using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	Text blueScore, redScore;
	int blueGoals, redGoals;
	bool gameIsOn;

	// Use this for initialization
	void Start () {
		blueScore = GameObject.Find ("Blue Team Score").GetComponent<Text>();
		redScore = GameObject.Find ("Red Team Score").GetComponent<Text>();
		blueGoals = 0;
		redGoals = 0;
	}
	
	// Update is called once per frame
	void Update () {
		gameIsOn = GetComponent<Timer>().GetGameIsOn ();
	}

	public void BlueTeamScores() {
		if (gameIsOn) {
			blueGoals++;
			ChangeScore ();
		}
	}

	public void RedTeamScores() {
		if (gameIsOn) {
			redGoals++;
			ChangeScore ();
		}
	}

	void ChangeScore() {
		blueScore.text = "" + blueGoals;
		redScore.text = "" + redGoals;
	}
}

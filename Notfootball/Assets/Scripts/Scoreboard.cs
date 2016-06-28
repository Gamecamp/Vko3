using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	Text blueScore, redScore;
	int blueGoals, redGoals;
	bool playersCanMove;

	// Use this for initialization
	void Start () {
		blueScore = GameObject.Find ("Blue Team Score").GetComponent<Text>();
		redScore = GameObject.Find ("Red Team Score").GetComponent<Text>();
		blueGoals = 0;
		redGoals = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playersCanMove = GetComponent<Timer>().GetPlayersCanMove ();
	}

	public void BlueTeamScores() {
		if (playersCanMove) {
			blueGoals++;
			ChangeScore ();
			GetComponent<Timer> ().StartCountdown ();
		}
	}

	public void RedTeamScores() {
		if (playersCanMove) {
			redGoals++;
			ChangeScore ();
			GetComponent<Timer> ().StartCountdown ();
		}
	}

	void ChangeScore() {
		blueScore.text = "" + blueGoals;
		redScore.text = "" + redGoals;
	}
}

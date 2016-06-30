using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	Text blueScore, redScore;
	int blueGoals, redGoals;
	bool playersCanMove;

	string redPlayer;
	string bluePlayer;

	// Use this for initialization
	void Start () {
		blueScore = GameObject.Find ("Blue Team Score").GetComponent<Text>();
		redScore = GameObject.Find ("Red Team Score").GetComponent<Text>();
		blueGoals = 0;
		redGoals = 0;
		bluePlayer = "Player1";
		redPlayer = "Player2";
	}
	
	// Update is called once per frame
	void Update () {
		playersCanMove = GetComponent<Timer>().GetPlayersCanMove ();
	}

	public void BlueTeamScores() {
		if (playersCanMove) {
			blueGoals++;
			GameObject.Find ("Goal Signal Light Blue").GetComponent<GoalSignalLight> ().GoalScored ();
			ChangeScore (bluePlayer);
		}
	}

	public void RedTeamScores() {
		if (playersCanMove) {
			redGoals++;
			GameObject.Find ("Goal Signal Light Red").GetComponent<GoalSignalLight> ().GoalScored ();
			ChangeScore (redPlayer);
		}
	}

	void ChangeScore(string playerWhoScored) {
		blueScore.text = "" + blueGoals;
		redScore.text = "" + redGoals;

		GetComponent<Timer> ().StartCountdown (playerWhoScored);
	}
}

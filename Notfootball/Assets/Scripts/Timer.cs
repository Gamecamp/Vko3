using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	Text time;
	Text countdown;
	float startTime;
	float timePassed;
	float startCountdown;
	float countdownTimePassed;
	bool gameIsOn;
	bool firstTimeInUpdate;
	bool isCountdownTime;
	bool playersCanMove;
	bool gameEnded;

	public int gameTime, firstCountdownTime, afterGoalCountdownTime;

	// Use this for initialization
	void Start () {
		SetGameIsOn (false);
		firstTimeInUpdate = true;
		gameEnded = false;
		time = GameObject.Find ("Time").GetComponent<Text> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		StartCountdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameIsOn) {
			
			if (firstTimeInUpdate) {
				startTime = Time.time;
				firstTimeInUpdate = false;
			}
			CalculateAndUpdateTime ();

			if (isCountdownTime) {
				
				countdownTimePassed = Time.time - startCountdown;
				countdownTimePassed = afterGoalCountdownTime - countdownTimePassed;
				Countdown ();

			}

		} else if (isCountdownTime && !gameEnded) {
			
			countdownTimePassed = Time.time - startCountdown;
			countdownTimePassed = firstCountdownTime - countdownTimePassed;
			Countdown ();
		
		}

	}

	public void StartCountdown() {
		startCountdown = Time.time;
		isCountdownTime = true;
	}

	void Countdown() {
		
		SetPlayersCanMove (false);
		countdown.enabled = true;

		if (countdownTimePassed > 1) {
			countdown.text = countdownTimePassed.ToString ("####");
		} else if (countdownTimePassed > 0) {
			countdown.text = "GO!";
		} else {
			SetGameIsOn (true);
			countdown.enabled = false;
			isCountdownTime = false;
		}
	}

	void CalculateAndUpdateTime() {
		timePassed = Time.time - startTime;
		timePassed = gameTime - timePassed;
		if (timePassed > 1) {
			time.text = timePassed.ToString ("####") + " s";
		} else if (timePassed > 0) {
			time.text = "1 s";
		} else {
			time.text = "Game Over!";
			SetGameIsOn (false);
		}
	}

	void SetGameIsOn(bool gameIsOn) {
		this.gameIsOn = gameIsOn;
		SetPlayersCanMove (gameIsOn);
		if (!gameIsOn) {
			gameEnded = true;
		}
	}

	void SetPlayersCanMove(bool playersCanMove) {
		this.playersCanMove = playersCanMove;
	}

	public bool GetPlayersCanMove() {
		return playersCanMove;
	}
}

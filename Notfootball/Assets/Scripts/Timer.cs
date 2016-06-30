﻿using UnityEngine;
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
	bool resetDone;

	public int countdownFontSize;
	public int announceGoalMakerFontSize;

	bool waitForRestart;

	string previousGoalMaker;

	public int gameTime, firstCountdownTime, afterGoalCountdownTime;

	// Use this for initialization
	void Start () {
		SetGameIsOn (false);
		firstTimeInUpdate = true;
		gameEnded = false;
		time = GameObject.Find ("Time").GetComponent<Text> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		previousGoalMaker = "";
		StartCountdown (previousGoalMaker);
		waitForRestart = true;
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

				if (waitForRestart) {
					AnnounceGoalMaker ();
					SetPlayersCanMove (false);
				}
	
				if (!waitForRestart) {
					Countdown ();
				}

			}

		} else if (isCountdownTime && !gameEnded) {
			
			countdownTimePassed = Time.time - startCountdown;
			countdownTimePassed = firstCountdownTime - countdownTimePassed;
			Countdown ();
		
		}

	}

	public void StartCountdown(string goalMaker) {
		previousGoalMaker = goalMaker;

		if (goalMaker == "Player1" || goalMaker == "Player2") {
			waitForRestart = true;
		}

		startCountdown = Time.time;
		isCountdownTime = true;
		resetDone = false;
	}

	void AnnounceGoalMaker() {
		countdown.enabled = true;
		countdown.fontSize = announceGoalMakerFontSize;
		countdown.text = previousGoalMaker + " scored!";

		if (countdownTimePassed <= 0.2f) {
			startCountdown = Time.time;
			waitForRestart = false;
		}
	}

	void Countdown() {
		if (!resetDone) {
			GameObject.Find ("GameManager").GetComponent<ResetPositions> ().ResetPosition ();
			resetDone = true;
		}

		SetPlayersCanMove (false);
		countdown.enabled = true;
		countdown.fontSize = countdownFontSize;


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

	public void SetPlayersCanMove(bool playersCanMove) {
		this.playersCanMove = playersCanMove;
	}

	public bool GetPlayersCanMove() {
		return playersCanMove;
	}
}

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

	public int gameTime, firstCountdownTime, afterGoalCountdownTime;

	// Use this for initialization
	void Start () {
		gameIsOn = false;
		firstTimeInUpdate = true;
		playersCanMove = false;
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

		} else if (isCountdownTime) {
			
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
		
		playersCanMove = false;
		countdown.enabled = true;

		if (countdownTimePassed > 1) {
			countdown.text = countdownTimePassed.ToString ("####");
		} else if (countdownTimePassed > 0) {
			countdown.text = "GO!";
		} else {
			gameIsOn = true;
			playersCanMove = true;
			countdown.enabled = false;
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
			gameIsOn = false;
			playersCanMove = false;
		}
	}

	public bool GetPlayersCanMove() {
		return playersCanMove;
	}
}

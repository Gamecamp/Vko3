using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	Text time;
	float startTime, timePassed;
	bool gameIsOn, firstTimeInUpdate;

	public int gameTime;

	// Use this for initialization
	void Start () {
		gameIsOn = false;
		firstTimeInUpdate = true;
		time = GameObject.Find ("Time").GetComponent<Text> ();
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
		}
	}

	void StartCountdown() {
		gameIsOn = true;
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
		}
	}
}

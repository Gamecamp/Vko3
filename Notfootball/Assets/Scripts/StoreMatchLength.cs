using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMatchLength : MonoBehaviour {

	float matchLength;
	Slider slider;

	// Use this for initialization
	void Start () {
		slider = GameObject.Find ("Slider").GetComponent<Slider> ();

		matchLength = slider.value;

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		matchLength = slider.value;
	}

	public float GetMatchLength() {
		return matchLength;
	}
}

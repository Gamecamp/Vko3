using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderHelper : MonoBehaviour {

	float sliderValue;
	Slider theSlider;
	Text theText;
	// Use this for initialization
	void Start () {
		theSlider = GetComponent<Slider> ();
		theText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		sliderValue = theSlider.value;
		theText.text = "\nGame length: " + sliderValue + " seconds";
	}
}

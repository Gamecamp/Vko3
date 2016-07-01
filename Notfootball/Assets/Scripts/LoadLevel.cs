using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	private string menu;
	private string game;

	// Use this for initialization
	void Start () {
		menu = "MenuScene";
		game = "Scene";
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void LoadScene() {


		if (Application.loadedLevelName == menu) {
			Application.LoadLevel (game);
		}

		if (Application.loadedLevelName == game) {
			Application.LoadLevel (menu);
		}
	}
}

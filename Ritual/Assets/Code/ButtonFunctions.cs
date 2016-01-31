using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	public string function = "NewGame";
	public bool run = false;

	// Update is called once per frame
	void Update () {
		if (run) {
			if (function == "NewGame") {
				SceneManager.LoadScene (1);
			} else if (function == "Exit") {
				Application.Quit ();
			} else if (function == "LoadGame") {
				SceneManager.LoadScene ("Level Select");
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	public string function = "NewGame";
	public bool run = false;

	// Update is called once per frame
	void Update () {
		if (run) {
			if(function == "NewGame"){
				Application.LoadLevel (1);
			}
			else if(function == "Exit"){
				Application.Quit();
			}
		}
	}
}

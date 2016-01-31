using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public int levelDisplay = 1;
	GameObject textPlace;
	GameObject playButton;
	MainControlCode cont;

	// Use this for initialization
	void Start () {
		textPlace = GameObject.Find ("LevelNumber");
		playButton = GameObject.Find ("PlayButton");
		cont = GameObject.Find("MainController").GetComponent<MainControlCode> ();
		if(!(cont.unlockedLevels.ints.Contains(levelDisplay))){
			textPlace.GetComponent<Text> ().text = levelDisplay.ToString();
		}
	}

	void oneMore () {
		levelDisplay++;
		if (levelDisplay > SceneManager.sceneCountInBuildSettings - 2) {
			levelDisplay = 1;
		}
		if (!(cont.unlockedLevels.ints.Contains (levelDisplay))) {
			textPlace.GetComponent<Text> ().text = levelDisplay.ToString ();
		}
	}
		
	void oneLess () {
		levelDisplay--;
		if (levelDisplay == 0) {
			levelDisplay = SceneManager.sceneCountInBuildSettings - 2;
		}
		if(!(cont.unlockedLevels.ints.Contains(levelDisplay))){
			playButton.GetComponent<Button> ().enabled = true;
			textPlace.GetComponent<Text> ().text = levelDisplay.ToString();
		}
	}

	void ChooseLevel() {
		SceneManager.LoadScene (levelDisplay);
	}
}

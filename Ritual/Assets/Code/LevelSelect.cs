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
		foreach (int s in cont.unlockedLevels.ints) {
			if (s == levelDisplay) {
				playButton.GetComponent<Button> ().enabled = true;
				goto exit;
			}
		}
		playButton.GetComponent<Button> ().enabled = false;
		exit:
		textPlace.GetComponent<Text> ().text = levelDisplay.ToString();
	}

	void oneMore () {
		levelDisplay++;
		if (levelDisplay > SceneManager.sceneCountInBuildSettings - 2) {
			levelDisplay = 1;
		}
		foreach (int s in cont.unlockedLevels.ints) {
			if (s == levelDisplay) {
				playButton.GetComponent<Button> ().enabled = true;
				goto exit;
			}
		}
		playButton.GetComponent<Button> ().enabled = false;
		exit:
		textPlace.GetComponent<Text> ().text = levelDisplay.ToString();
	}
		
	void oneLess () {
		levelDisplay--;
		if (levelDisplay == 0) {
			levelDisplay = SceneManager.sceneCountInBuildSettings - 2;
		}
		foreach (int s in cont.unlockedLevels.ints) {
			if (s == levelDisplay) {
				playButton.GetComponent<Button> ().enabled = true;
				goto exit;
			}
		}
		playButton.GetComponent<Button> ().enabled = false;
		exit:
		textPlace.GetComponent<Text> ().text = levelDisplay.ToString();
	}

	void ChooseLevel() {
		SceneManager.LoadScene (levelDisplay);
	}
}

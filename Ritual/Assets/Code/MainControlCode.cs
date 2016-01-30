using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainControlCode : MonoBehaviour {

	GameObject wall;
	Material mat;
	Color changer = new Color (0.80f, 1, 1, 1);
	int color = 3;

	void Start(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void OnLevelWasLoaded () {
		if (FindObjectsOfType<MainControlCode> ().Length > 1) {
			if (this != FindObjectsOfType<MainControlCode> () [1]) {
				changer = colorCycle (changer);
				wall = GameObject.Find ("Background");
				mat = wall.GetComponent <Renderer> ().material;
				mat.color = changer;
			}
			DestroyObject (FindObjectsOfType<MainControlCode> () [1]);
		} else {
			changer = colorCycle (changer);
			wall = GameObject.Find ("Background");
			mat = wall.GetComponent <Renderer> ().material;
			mat.color = changer;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Backspace)) {
			SceneManager.LoadScene(0);
		}
	}

	Color colorCycle(Color c){
		if (c.r < 1 && color != 3) {
			c.r += 0.02f;
			c.g -= 0.02f;
			color = 1;
		} else if (c.g < 1) {
			c.g += 0.02f;
			c.b -= 0.02f;
			color = 2;
		} else if (c.b < 1) {
			c.b += 0.02f;
			c.r -= 0.02f;
			color = 3;
		} else if(c.b >= 1){
			color = 1;
		}
		return c;
	}
}

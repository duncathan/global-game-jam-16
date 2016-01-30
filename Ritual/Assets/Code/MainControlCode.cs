using UnityEngine;
using System.Collections;

public class MainControlCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType<MainControlCode> () [1]!= null) {
			DestroyObject(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Backspace)) {
			Application.LoadLevel(0);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	float mouseX = 0.0f;
	Vector3 clickPosition = new Vector3 (0,0,0);
	bool testForMouse = true;
	bool runMove = false;

	void Update () {
		if (testForMouse && Input.GetMouseButtonDown (0)) {
			if (!runMove) {
				clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D[] Hits = Physics2D.RaycastAll (clickPosition, clickPosition);
				testForMouse = false;
				foreach (RaycastHit2D hit in Hits) {
					if (hit.rigidbody == this.gameObject.GetComponent<Rigidbody2D> ()) {
						runMove = true;
						mouseX = clickPosition.x;
					}
				}
			}
		} else if (Input.GetMouseButtonUp (0)) {
			testForMouse = true;
			runMove = false;
		} else if (runMove) {
			clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if(mouseX != clickPosition.x){
				transform.Rotate (0,0,(mouseX-clickPosition.x)*10);
				mouseX = clickPosition.x;
			}
		}
	}
}

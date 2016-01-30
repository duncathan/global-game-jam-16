using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	float mouseX = 0.0f;
	Vector3 clickPosition = new Vector3 (0,0,0);
	Vector3 position = new Vector3 (0,0,0);
	bool testForMouse = true;
	bool runMove = false;

	void Start () {
		position = transform.localPosition;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Rigidbody2D hitBody = col.collider.attachedRigidbody;
		if (hitBody != null) {
			hitBody.AddForce (col.relativeVelocity);
		}
	}

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
				gameObject.GetComponent<Rigidbody2D>().AddTorque((mouseX-clickPosition.x)*10000000);
				//mouseX = clickPosition.x;
			}
		}
		transform.localPosition = position;
	}
}

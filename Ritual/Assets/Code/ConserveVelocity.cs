using UnityEngine;
using System.Collections;

public class ConserveVelocity : MonoBehaviour {

	Vector2 prevPos = new Vector2 (0,0);
	Rigidbody2D body;
	bool delayTick = false;

	void Start() {
		prevPos = new Vector2(transform.localPosition.x,transform.localPosition.y);
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		Vector2 deltaP = new Vector2 (-(prevPos.x - transform.localPosition.x),-(prevPos.y - transform.localPosition.y));
		if (body.velocity != new Vector2(deltaP.x/Time.deltaTime, deltaP.y/Time.deltaTime) && !delayTick) {
			body.velocity = new Vector2(deltaP.x/Time.deltaTime, deltaP.y/Time.deltaTime);
			prevPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
			delayTick = true;
		}
		prevPos = new Vector2 (transform.localPosition.x, transform.localPosition.y);
		if (delayTick) {
			delayTick = false;
		}
	}
}

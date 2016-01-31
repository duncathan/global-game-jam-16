using UnityEngine;
using System.Collections;

public class Rotate : Transformable {
    int torqueCoefficient = 10000000; //i love magic numbers

    void Start () {
		position = transform.localPosition;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Rigidbody2D hitBody = col.collider.attachedRigidbody;
		if (hitBody != null) {
			hitBody.AddForce (col.relativeVelocity);
		}
	}

    protected override void Transform()
    {
        base.Transform();
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float mouseMagnitude = Mathf.Abs((mouseX - clickPosition.x)*(mouseY - clickPosition.y));
		float mouseDir = ((mouseX - clickPosition.x) - (mouseY - clickPosition.y)) / Mathf.Abs ((mouseX - clickPosition.x) - (mouseY - clickPosition.y)+0.001f);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(mouseDir * mouseMagnitude * torqueCoefficient + 1f);
    }
}


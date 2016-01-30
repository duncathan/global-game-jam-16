using UnityEngine;
using System.Collections;

public class Translate : Transformable {
    //which directions does it translate in?
	public bool moveX = false;
	public bool moveY = false;
	
    protected override void Transform ()
    {
        base.Transform();
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseX != clickPosition.x && moveX) {
            transform.Translate(-(mouseX - clickPosition.x), 0, 0);
            mouseX = clickPosition.x;
        }
        if (mouseY != clickPosition.y && moveY) {
            transform.Translate(0, -(mouseY - clickPosition.y), 0);
            mouseY = clickPosition.y;
        }
    }

}
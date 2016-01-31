using UnityEngine;
using System.Collections;

public class Stretch : Transformable {
    //which directions does it scale in?
	public bool scaleX = false;
	public bool scaleY = false;

	
	void Start () {
		position = transform.localPosition;
	}

	protected override void Transform ()
    {
        base.Transform();
	    clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if(mouseX != clickPosition.x && scaleX){
			transform.localScale += new Vector3(-(mouseX-clickPosition.x),0,0);
			mouseX = clickPosition.x;
		}
		if(mouseY != clickPosition.y && scaleY){
			transform.localScale += new Vector3(0,-(mouseY - clickPosition.y),0);
			mouseY = clickPosition.y;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Translate : Transformable {
    //which directions does it translate in?
	public bool moveX = false;
	public bool moveY = false;
	
	void Start () {
		position = transform.localPosition;
	}

    protected override void Transform ()
    {
        base.Transform();
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseX != clickPosition.x && moveX) 
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (-40*(mouseX - clickPosition.x), 0);
			mouseX = clickPosition.x;
		} else 
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
		if (mouseY != clickPosition.y && moveY) 
		{
			gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2 (0, -40*(mouseY - clickPosition.y));
			mouseY = clickPosition.y;
		} else 
		{
			gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(0,gameObject.GetComponent<Rigidbody2D>().velocity.y);
		}
		position = transform.localPosition;
    }

}
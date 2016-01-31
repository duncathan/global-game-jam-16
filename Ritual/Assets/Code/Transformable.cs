using UnityEngine;

public class Transformable : MonoBehaviour
{
    //current position of the object
    protected Vector3 position = new Vector3(0, 0, 0);

    //mouse locations
    protected float mouseX = 0.0f;
    protected float mouseY = 0.0f;
    protected Vector3 clickPosition = new Vector3(0, 0, 0);

    //is the object going to transform on the next Update() tick?
    protected bool transformOnUpdate = false;

    protected void Update()
    {
        if(transformOnUpdate)
        {
            Transform();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] Hits = Physics2D.RaycastAll(clickPosition, clickPosition);
            foreach (RaycastHit2D hit in Hits)
            {
                if (hit.rigidbody == this.gameObject.GetComponent<Rigidbody2D>())
                {
                    transformOnUpdate = true;
                    mouseX = clickPosition.x;
                    mouseY = clickPosition.y;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            transformOnUpdate = false;
        }
        transform.localPosition = position; //update the position of the transform to account for potential movements during Transform()
    }

    virtual protected void Transform()
    {

    }
}

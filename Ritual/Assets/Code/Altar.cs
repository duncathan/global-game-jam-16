using UnityEngine;
using System.Collections;

public class Altar : MonoBehaviour {

	GameObject target;
	Collider2D[] touchers; 

	void Start() {
		target = GameObject.Find ("MainSphere");
	}

	void Update(){
		touchers = Physics2D.OverlapAreaAll (new Vector2 (-1, -4.25f), new Vector2 (1, -3.75f));
		foreach (Collider2D col in touchers) {
			if(col.gameObject==target.gameObject){
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}
	}
}

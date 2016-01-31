using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Altar : MonoBehaviour {

	GameObject target;
	Collider2D[] touchers; 

	void Start() {
		target = GameObject.Find ("MainSphere");
	}

	void Update(){
		touchers = Physics2D.OverlapAreaAll (new Vector2 (-1+transform.position.x, -4.25f+transform.position.y), new Vector2 (1+transform.position.x, -3.75f+transform.position.y));
		foreach (Collider2D col in touchers) {
			if (col.gameObject == target.gameObject) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
		}
	}
}

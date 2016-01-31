using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

[System.Serializable]
public class intList{
	public List<int> ints = new List<int>();

	public void Add(int x){
		ints.Add (x);
	}
}
	
public class MainControlCode : MonoBehaviour {

	GameObject wall;
	Material mat;

	Color changer = new Color (0.80f, 1, 1, 1);
	int color = 3;

	public intList unlockedLevels = new intList();

	MusicHandler music;

	void Start(){
		DontDestroyOnLoad (transform.gameObject);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/LevelsDone.ld", FileMode.OpenOrCreate);
		unlockedLevels = (intList)bf.Deserialize (file);
		file.Close ();
		music = new MusicHandler ();
		music.start ();
	}

	void OnLevelWasLoaded () {
		if (!(unlockedLevels.ints.Contains (SceneManager.GetActiveScene().buildIndex))) {
			unlockedLevels.Add (SceneManager.GetActiveScene ().buildIndex);
		}
		if (FindObjectsOfType<MainControlCode> ().Length > 1) {
			if (this != FindObjectsOfType<MainControlCode> () [1]) {
				changer = colorCycle (changer);
				wall = GameObject.Find ("Background");
				mat = wall.GetComponent <Renderer> ().material;
				mat.color = changer;
			}
			DestroyObject (FindObjectsOfType<MainControlCode> () [1]);
		} else {
			changer = colorCycle (changer);
			wall = GameObject.Find ("Background");
			mat = wall.GetComponent <Renderer> ().material;
			mat.color = changer;
		}

		switch (SceneManager.GetActiveScene ().buildIndex) {
		case 1:
			music.setScene (0);
			break;
		case 4:
			music.setScene (1);
			break;
		case 7:
			music.setScene (2);
			break;
		case 10:
			music.setScene (3);
			break;
		case 13:
			music.setScene (4);
			break;
		case 16:
			music.setScene (5);
			break;
		case 19:
			music.setScene (6);
			break;
		case 20:
			music.setScene (5);
			break;
			
		}
	}

	void menu () {
		SceneManager.LoadScene(0);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open(Application.persistentDataPath + "/LevelsDone.ld", FileMode.OpenOrCreate);
		bf.Serialize (file, unlockedLevels);
		file.Close ();
	}

	void restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	Color colorCycle(Color c){
		if (c.r < 1 && color != 3) {
			c.r += 0.02f;
			c.g -= 0.02f;
			color = 1;
		} else if (c.g < 1) {
			c.g += 0.02f;
			c.b -= 0.02f;
			color = 2;
		} else if (c.b < 1) {
			c.b += 0.02f;
			c.r -= 0.02f;
			color = 3;
		} else if(c.b >= 1){
			color = 1;
		}
		return c;
	}
}

class MusicHandler
{
	static FMOD.Studio.System FMOD_StudioSytem;
	FMOD.Studio.EventInstance music;
	const int totalScenes = 7;
	const int sceneLength = 32*1000; //milliseconds

	public void setScene(int newScene)
	{
		if (newScene < 0 || newScene >= totalScenes) {
			return;
		}

		int timelineCurrent;
		music.getTimelinePosition (out timelineCurrent);

		int currentScene = timelineCurrent / sceneLength;
		int sceneDifference = newScene - currentScene;
		int timeDifference = sceneDifference * sceneLength;
		int newTime = timelineCurrent + timeDifference;

		music.setTimelinePosition (newTime);
	}

	public void start()
	{
		Debug.Log ("Running!");
		FMOD.Studio.System.create (out FMOD_StudioSytem);
		FMOD.Studio.EventDescription desc;
		FMOD_StudioSytem.getEvent ("event:/Music", out desc);
		desc.createInstance (out music);
		music.start ();
		//Debug.Log(
	}
}
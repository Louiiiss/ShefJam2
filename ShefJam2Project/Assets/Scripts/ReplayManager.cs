using UnityEngine;
using System.Collections;

public class ReplayManager : MonoBehaviour {

	private LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("A 1 Button") || Input.GetButtonDown("A 2 Button")){
			lm.loadLevel("Scene 1");
		}
	}
}

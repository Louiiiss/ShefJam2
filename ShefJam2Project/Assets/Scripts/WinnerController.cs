using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnerController : MonoBehaviour {

	Text WinnerText;
	static int winner;
	LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.FindObjectOfType<LevelManager>();
		winner = LevelManager.ending;	
		WinnerText = gameObject.GetComponent<Text>();

		if (winner == 1){
			WinnerText.text = "Winner: \n Detective Angelman (P1)";	
		}
		else {
			WinnerText.text = "Winner: \n Doctor Van Pyre (P2)";	
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

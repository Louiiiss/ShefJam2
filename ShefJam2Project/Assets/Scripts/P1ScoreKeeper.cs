using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1ScoreKeeper : MonoBehaviour {

	private LevelManager lm;
	public static int P1Val;
	Text P1Score;

	// Use this for initialization
	void Start () {
		P1Val = 0;
		P1Score = gameObject.GetComponent<Text>();
		lm = GameObject.FindObjectOfType<LevelManager>();
	}

	public void Increment(){
		P1Val += 1;
	}

	public static void Reset() {
		P1Val = 0;
	}

	void Update(){
		P1Score.text = P1Val.ToString();
		if (P1Val >= 10){
			lm.LoadNextLevel();
		}
	}
}

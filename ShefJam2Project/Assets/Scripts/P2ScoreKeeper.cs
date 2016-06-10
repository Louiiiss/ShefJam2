using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P2ScoreKeeper : MonoBehaviour {

	private LevelManager lm;
	public static int P2Val;
	Text P2Score;

	// Use this for initialization
	void Start () {
		P2Val = 0;
		P2Score = gameObject.GetComponent<Text>();
		lm = GameObject.FindObjectOfType<LevelManager>();
	}

	public void Increment(){
		P2Val += 1;
	}

	public static void Reset() {
		P2Val = 0;
	}

	void Update(){
		P2Score.text = P2Val.ToString();

		if (P2Val >= 10){
			lm.LoadNextLevel();
		}
	}
}

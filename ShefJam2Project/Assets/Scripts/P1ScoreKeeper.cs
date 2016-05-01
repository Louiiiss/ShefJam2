using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1ScoreKeeper : MonoBehaviour {

	public static int P1Val;
	Text P1Score;

	// Use this for initialization
	void Start () {
		P1Val = 0;
		P1Score = gameObject.GetComponent<Text>();
	}

	public void Increment(){
		P1Val += 1;
	}

	public static void Reset() {
		P1Val = 0;
	}

	void Update(){
		P1Score.text = P1Val.ToString();
	}
}

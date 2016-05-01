using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1AmmoKeeper : MonoBehaviour {

	public static int P1A;
	Text P1Ammo;
	private float reloadTime;

	// Use this for initialization
	void Start () {
		P1A = 5;
		reloadTime = 0;
		P1Ammo = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		reloadTime-=Time.deltaTime;
		string count = "";
		if(reloadTime<0){
			for (int i = 1; i<=P1A; i++){
				count += ".";
			}
			count = count.ToString();
		}
		P1Ammo.text = "" + count;
	}

	public void Reduce(){
		P1A -= 1;
	}

	public void Reset() {
		P1A = 5;
		reloadTime=1f;
	}
}

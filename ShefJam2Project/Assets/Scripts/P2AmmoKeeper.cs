using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P2AmmoKeeper : MonoBehaviour {

	public static int P2A;
	Text P2Ammo;
	private float reloadTime;

	// Use this for initialization
	void Start () {
		P2A = 5;
		reloadTime = 0;
		P2Ammo = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		reloadTime-=Time.deltaTime;
		string count = "";
		if(reloadTime<0){
			for (int i = 1; i<=P2A; i++){
				count += ".";
			}
			count = count.ToString();
		}
		P2Ammo.text = "" + count;
	}

	public void Reduce(){
		P2A -= 1;
	}

	public void Reset() {
		P2A = 5;
		reloadTime=1f;
	}
}

using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private float counter = 5f;

	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.name != this.gameObject.name && col.gameObject.name != "Shield(Clone)" && col.gameObject.name != "Shield2(Clone)" ){
			counter -= 1;
			Debug.Log("Hit " + col.gameObject.name);
		}
		if(col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2"){
			Destroy(gameObject);
		}
		CheckCounter();
	}

	void CheckCounter(){
		if (counter <= 0){
			Destroy(gameObject);
		}
	}
}

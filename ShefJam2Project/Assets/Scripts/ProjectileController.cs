using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private float counter = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;

		if (counter <= 0){
			Destroy(gameObject);
		}

	}
}

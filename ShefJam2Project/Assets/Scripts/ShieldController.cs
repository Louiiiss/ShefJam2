using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {

	public AudioClip deflectSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint(deflectSound, transform.position);
	}

}

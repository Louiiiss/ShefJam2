using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyPlayerController2 : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 startPos;
	private Transform thisTransform;
	public GameObject aimer;
	private Vector3 distance;
	private Vector3 inputDirection;
	private Vector3 inputDirectionAimer;
	public GameObject projectile;
	public float laserSpeed = 25;

	// Use this for initialization
	void Start () {
		distance = new Vector3(5,0,0);
		thisTransform = transform;
		startPos = thisTransform.position;
		//aimer = FindObjectOfType(GameObject);
		aimer = Instantiate(aimer, thisTransform.position + distance, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		

		inputDirection = Vector3.zero;
		inputDirection.x = Input.GetAxis("left joystick 2 horizontal");
		inputDirection.y = -(Input.GetAxis("left joystick 2 vertical"));
		thisTransform.position += inputDirection;

		inputDirectionAimer = Vector3.zero;
		inputDirectionAimer.x = Input.GetAxis("right joystick 2 horizontal");
		inputDirectionAimer.y = -(Input.GetAxis("right joystick 2 vertical"));
		aimer.transform.position = thisTransform.position + inputDirectionAimer; 


		if(Input.GetAxis("RT 2")>0){
			Fire();
		}

		if(Input.GetAxis("LT 2")>0){
			Fire();
		}


	}

	void Fire(){
		GameObject laser = Instantiate(projectile,transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = Vector3.up * laserSpeed;
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);


	}
}

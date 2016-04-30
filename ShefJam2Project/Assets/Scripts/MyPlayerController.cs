using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyPlayerController : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 startPos;
	private Transform thisTransform;
	public GameObject aimer;
	private Vector3 distance;
	private Vector3 inputDirection;
	private Vector3 inputDirectionAimer;
	public GameObject projectile;
	public float laserSpeed = 25;
	private float angle;
	private float oldAngle = 0;
	private Vector3 aimDirection;

	// Use this for initialization
	void Start () {
		distance = new Vector3(2,0,0);
		thisTransform = transform;
		startPos = thisTransform.position;
		//aimer = FindObjectOfType(GameObject);
		aimer = Instantiate(aimer, thisTransform.position + distance, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		

		inputDirection = Vector3.zero;
		inputDirection.x = Input.GetAxis("left joystick 1 horizontal");
		inputDirection.y = -(Input.GetAxis("left joystick 1 vertical"));
		thisTransform.position += inputDirection;


		//Vector3 vNewInput = new Vector3(Input.GetAxis("right joystick 1 horizontal"), Input.GetAxis("right joystick 1 vertical"), 0.0f);
		angle = Mathf.Atan2(Input.GetAxis("right joystick 1 horizontal"), Input.GetAxis("right joystick 1 vertical")) * Mathf.Rad2Deg;


		// Dead Zone
		if(Input.GetAxis("right joystick 1 horizontal") > 0.3 || Input.GetAxis("right joystick 1 vertical") > 0.3 || Input.GetAxis("right joystick 1 horizontal") < -0.3 || Input.GetAxis("right joystick 1 vertical") < -0.3){
			oldAngle = angle;
		}


		aimDirection = Quaternion.Euler(0, 0, oldAngle - 90) * distance;


		aimer.transform.position = thisTransform.position + aimDirection;


/*		inputDirectionAimer = Vector3.zero;
		inputDirectionAimer.x = Input.GetAxis("right joystick 1 horizontal");
		inputDirectionAimer.y = -(Input.GetAxis("right joystick 1 vertical"));
		aimer.transform.position = thisTransform.position + inputDirectionAimer; */


		if(Input.GetAxis("RT 1")>0){
			Fire();
		}

		if(Input.GetAxis("LT 1")>0){
			Fire();
		}

	}

	void Fire(){
		GameObject laser = Instantiate(projectile,thisTransform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = aimDirection * laserSpeed;
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
}

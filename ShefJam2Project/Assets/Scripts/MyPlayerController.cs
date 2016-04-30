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
	public GameObject shield;
	private float fireCooldown;

	// Use this for initialization
	void Start () {
		fireCooldown = 1f;
		distance = new Vector3(2,0,0);
		thisTransform = transform;
		startPos = thisTransform.position;
		//aimer = FindObjectOfType(GameObject);
		aimer = Instantiate(aimer, thisTransform.position + distance, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		fireCooldown -= Time.deltaTime;

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



		if(Input.GetAxis("RT 1")>0.2){
			if (thisTransform.childCount < 1){
				if(fireCooldown < 0){
					Fire();
					fireCooldown = 1f;
				}
			}
		} 
		if (Input.GetAxis("RT 1") <= 0.2){
			fireCooldown = 0;
			}
		

		if (thisTransform.childCount <1) {
			if(Input.GetAxis("LT 1")>0){
				Defend();
				//InvokeRepeating("Defend", 0.00001f, 10f);
			}
		}

		if(Input.GetAxis("LT 1")<=0){
			//shield = FindObjectOfType(GameObject);
			foreach(Transform child in thisTransform){
				Destroy(child.gameObject);
			}
			;
		}
	}

	void Fire(){

		GameObject projectileObj = Instantiate(projectile,thisTransform.position, Quaternion.identity) as GameObject;
		projectileObj.GetComponent<Rigidbody2D>().velocity = aimDirection * laserSpeed;
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void Defend(){
		GameObject shieldObj = Instantiate(shield, aimer.transform.position, Quaternion.identity) as GameObject;
		shieldObj.transform.parent = GameObject.Find("Player 1").transform;
	}
}

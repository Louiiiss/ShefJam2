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
	private Vector3 rawInputDireciton; 
	private Vector3 inputDirectionAimer;
	public GameObject projectile;
	public float projectileSpeed = 8;
	private float angle;
	private float LSangle;
	private float oldAngle = 0;
	private float LSoldAngle = 0;
	private Vector3 aimDirection;
	private Vector3 shieldDirection;
	private Vector3 bulletDirection;
	public GameObject shield;
	private float fireCooldown;
	private Vector3 shieldDistance;
	private Vector3 bulletDistance;
	private float dashTime = 0;
	private Vector3 dashDistance;
	private Vector3 dashDirection;
	private float dashSpeed = 20f;
	private float dashCooldown;
	private P2ScoreKeeper p2score;
	private EventHandler handler;
	private int invLayer;
	private int currentLayer;
	private Collider2D playerCol;
	private P1AmmoKeeper P1Ammo;

	private GameObject s;
	private int ammo = 5;
	private float reloadTime = 1f;
	private int curammo;
	private float curreloadTime;

	// Use this for initialization
	void Start () {

		currentLayer = LayerMask.NameToLayer("Players");
		invLayer = LayerMask.NameToLayer("Invulnerable");

		fireCooldown = 1f;
		curammo = ammo;

		distance = new Vector3(2,0,0);
		shieldDistance = new Vector3(0.7f,0,0);
		bulletDistance = new Vector3(1f,0,0);
		dashDistance = new Vector3(3,0,0);
		thisTransform = transform;
		startPos = thisTransform.position;
		//aimer = FindObjectOfType(GameObject);
		aimer = Instantiate(aimer, thisTransform.position + distance, Quaternion.identity) as GameObject;
		p2score = GameObject.Find("P2 Score").GetComponent<P2ScoreKeeper>();

		handler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
		P1Ammo = GameObject.Find("P1 Ammo").GetComponent<P1AmmoKeeper>();

		playerCol = this.GetComponent<Collider2D>();

	}

	// Update is called once per frame
	void Update () {
		fireCooldown -= Time.deltaTime;
		dashTime -= Time.deltaTime;
		dashCooldown -= Time.deltaTime;
		curreloadTime -= Time.deltaTime;

		s = GameObject.Find("Shield(Clone)");

		if (dashTime <= 0){
			thisTransform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}

		inputDirection = Vector3.zero;
		inputDirection.x = Input.GetAxis("left joystick 1 horizontal");
		inputDirection.y = -(Input.GetAxis("left joystick 1 vertical"));


		LSangle = Mathf.Atan2(Input.GetAxis("left joystick 1 horizontal"), Input.GetAxis("left joystick 1 vertical")) * Mathf.Rad2Deg;
		// Dead Zone

		if(Input.GetAxis("left joystick 1 horizontal") > 0.3 || Input.GetAxis("left joystick 1 vertical") > 0.3 || Input.GetAxis("left joystick 1 horizontal") < -0.3 || Input.GetAxis("left joystick 1 vertical") < -0.3){
			LSoldAngle = LSangle;
		}


		if(Input.GetButtonDown("A 1 Button") && dashCooldown < 0){
			dashTime = 0.1f;
			Dash(LSoldAngle);
			Invulnerable(playerCol);

		}
		else if (dashTime < 0) {
			thisTransform.position += inputDirection * 0.2f;
			thisTransform.rotation = Quaternion.identity;
			if (dashTime <= -0.2){
				Vulnerable(playerCol);
			}
		}


		//Vector3 vNewInput = new Vector3(Input.GetAxis("right joystick 1 horizontal"), Input.GetAxis("right joystick 1 vertical"), 0.0f);
		angle = Mathf.Atan2(Input.GetAxis("right joystick 1 horizontal"), Input.GetAxis("right joystick 1 vertical")) * Mathf.Rad2Deg;
		// Dead Zone
		if(Input.GetAxis("right joystick 1 horizontal") > 0.3 || Input.GetAxis("right joystick 1 vertical") > 0.3 || Input.GetAxis("right joystick 1 horizontal") < -0.3 || Input.GetAxis("right joystick 1 vertical") < -0.3){
			oldAngle = angle;
		}



		aimDirection = Quaternion.Euler(0, 0, oldAngle - 90) * distance;
		shieldDirection = Quaternion.Euler(0, 0, oldAngle - 90) * shieldDistance;
		bulletDirection = Quaternion.Euler(0, 0, oldAngle - 90) * bulletDistance;


		aimer.transform.position = thisTransform.position + aimDirection;

		if (s==null){
			if(Input.GetAxis("LT 1")>0){
				Defend();
			}
		}
		

		if(Input.GetAxis("RT 1")>0.2){
			if (s==null){
				if(fireCooldown < 0 && curreloadTime < 0){
					Fire();
					curammo --;
					P1Ammo.Reduce();
					fireCooldown = 1f;
				}
				if(curammo == 0){
					Reload();
					P1Ammo.Reset();	
				}
			}
		} 
		if (Input.GetAxis("RT 1") <= 0.2){
			fireCooldown = 0;
		}



		if(s!=null){
			//Debug.Log("finds object");
			if(Input.GetAxis("LT 1")<=0.1){
				Destroy(GameObject.Find("Shield(Clone)"));
			}
			s.transform.position = thisTransform.position + shieldDirection;
			s.transform.rotation = Quaternion.Euler(0, 0, oldAngle - 135);
		}
	}

	void Fire(){

		GameObject projectileObj = Instantiate(projectile,(thisTransform.position + bulletDirection), Quaternion.identity) as GameObject;
		projectileObj.GetComponent<Rigidbody2D>().velocity = aimDirection * projectileSpeed;
		//AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void Defend(){
		GameObject shieldObj = Instantiate(shield, (thisTransform.position + shieldDirection), Quaternion.Euler(0, 0, oldAngle - 135)) as GameObject;
	}

	void Dash(float angle){
		dashDirection = Quaternion.Euler(0, 0, angle - 90) * dashDistance;
		thisTransform.GetComponent<Rigidbody2D>().velocity = dashDirection * dashSpeed;
		dashCooldown = 1f;
	}



	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.name == "Bullet(Clone)" ){
			Debug.Log("Hit " + col.gameObject.name);
			p2score.Increment();
			DestroyAll();
			handler.InitialiseNextPhase();
		}
	}

	void DestroyAll(){
		Destroy(gameObject);
		Destroy(aimer.gameObject);
		if (GameObject.Find("Shield(Clone)")){
			Destroy(GameObject.Find("Shield(Clone)"));
		}
	}

	void Invulnerable(Collider2D col){
		col.gameObject.layer = invLayer;
	}

	void Vulnerable(Collider2D col){
		col.gameObject.layer = currentLayer;
	}

	void Reload(){
		curammo = ammo;
		curreloadTime = reloadTime;
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventHandler : MonoBehaviour {

	private GameObject Banner;
	private BannerController bc;
	float counter = 1.5f;
	private GameObject p1;
	private GameObject p2;
	private GameObject p1Spawn;
	private GameObject p2Spawn;
	public GameObject player1;
	public GameObject player2;
	private bool spawned ;
	private P1AmmoKeeper P1Ammo;
	private P2AmmoKeeper P2Ammo;
	float delay;
	bool goDelay = false;

	// Use this for initialization
	void Start () {

		P1Ammo = GameObject.Find("P1 Ammo").GetComponent<P1AmmoKeeper>();
		P2Ammo = GameObject.Find("P2 Ammo").GetComponent<P2AmmoKeeper>();

		p1Spawn = GameObject.Find("P1Spawn");
		p2Spawn = GameObject.Find("P2Spawn");

		Banner = GameObject.Find("Banner");
		bc = Banner.GetComponent<BannerController>();
		//bc.ShowBanner();


/*		p1 = Instantiate(player1, p1Spawn.transform.position, Quaternion.identity) as GameObject;
		p2 = Instantiate(player2, p2Spawn.transform.position, Quaternion.identity) as GameObject;*/
		spawned = false;

		p1 = GameObject.Find("Player 1(Clone)");
		p2 = GameObject.Find("Player 2(Clone)");

		



	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if (goDelay) {
			delay -= Time.deltaTime;
		}
	
		if (counter <= 0){
			bc.HideBanner();
			if (!spawned){
				p1 = Instantiate(player1, p1Spawn.transform.position, Quaternion.identity) as GameObject;
				p2 = Instantiate(player2, p2Spawn.transform.position, Quaternion.identity) as GameObject;
				spawned=true;
			}
		}

		if (delay < 0){
			goDelay = false;
			delay = 0;
			NextPhaseActual();
		}

	}

	public void InitialiseNextPhase(){
		delay = 1f;
		goDelay = true;


	}

	public void NextPhaseActual(){
		DestroyEverything();
		spawned = false;
		bc.Increment();
		bc.ShowBanner();
		counter = 1.5f;
		P1Ammo.Reset();	
		P2Ammo.Reset();	
		/*		p1.transform.position = p1Spawn.transform.position;
		p2.transform.position = p2Spawn.transform.position;*/
	}

	void DestroyEverything(){
		Destroy(p1);
		Destroy(p2);

		foreach(GameObject bullet in GameObject.FindGameObjectsWithTag("bullet")){
			Destroy(bullet);
		}

		foreach(GameObject death in GameObject.FindGameObjectsWithTag("death")){
			Destroy(death);
		}


		foreach(GameObject aimer in GameObject.FindGameObjectsWithTag("aimer")){
			Destroy(aimer);
		}

		foreach(GameObject shield in GameObject.FindGameObjectsWithTag("Shield")){
			Destroy(shield);
		}
	}
}

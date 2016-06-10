using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BannerController : MonoBehaviour {

	public static int BannerVal;
	Text BannerText;
	public AudioClip phaseSound;

	// Use this for initialization
	void Start () {
		BannerText = gameObject.GetComponent<Text>();
		BannerVal = 1;
		ShowBanner();
	}

	public void Increment(){
		BannerVal += 1;
	}

	public void HideBanner() {
		BannerText.text = "";
	}

	public void ShowBanner() {
		AudioSource.PlayClipAtPoint(phaseSound, Vector3.zero);
		BannerText.text = "PHASE " + BannerVal.ToString();
	}

	void Update(){

	}
}

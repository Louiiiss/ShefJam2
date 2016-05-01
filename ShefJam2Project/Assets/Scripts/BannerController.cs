using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BannerController : MonoBehaviour {

	public static int BannerVal;
	Text BannerText;

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
		BannerText.text = "PHASE " + BannerVal.ToString();
	}

	void Update(){

	}
}

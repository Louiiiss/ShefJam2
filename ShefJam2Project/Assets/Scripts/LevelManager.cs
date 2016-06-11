using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static int ending;

	public void loadLevel (string name) {
	Debug.Log("Level load requested for: " + name);
	Application.LoadLevel(name);
	}
	
	public void quitRequest (){
	Debug.Log("Quit request initiated");
	Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void setWinner(int num){
		ending = num;
	}
		

}

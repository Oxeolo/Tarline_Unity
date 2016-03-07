using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour {
	private bool has_been_opened_before = false;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("OPENED_BEFORE") == true) {
			has_been_opened_before = false; // indicates the game has been opened before
		} else {
			PlayerPrefs.SetInt ("OPENED_BEFORE",1);
			//first time setup
			PlayerPrefs.SetInt("HighScore",0);
			has_been_opened_before =  true;
			PlayerPrefs.Save();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool IsFirstTime(){
		return has_been_opened_before;
	}
	public static int GetHighScore(){
		return PlayerPrefs.GetInt("HighScore");
	}
	public static void SetHighScore(int highscore){
		PlayerPrefs.SetInt ("HighScore", 0);
		PlayerPrefs.Save ();
	}
	public static void Save(){
		PlayerPrefs.Save ();
	}
}
	
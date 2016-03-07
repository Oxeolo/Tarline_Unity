using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {
	public static string Scene_To_Load = "";
	// Handle Click events

	void OnMouseDown(){
		switch (gameObject.name) {
		case "Play_Gold":
			Scene_To_Load = "MainGame";
			break;
		//case "Settings_Mint":
			//Scene_To_Load = "Settings";
			//break;
		//case "Leaderboards_Blue":
		//	Scene_To_Load = "Leaderboards";
		//	break;
		}
		Animator transition = Camera.main.GetComponent<Animator> ();
		transition.Play ("StartMenu_Camera_RotateAway");

	}

	public void Change_Scene(){
		Application.LoadLevel (Scene_To_Load);
	}

}






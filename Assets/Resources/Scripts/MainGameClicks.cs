using UnityEngine;
using System.Collections;

public class MainGameClicks : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//handle normal rotate clicks
		switch(MainGameManager.current_game_state){
			case MainGameManager.game_state.PreStart:
			MainGameManager.Start_Game();
			break;
			case MainGameManager.game_state.Playing:
			if (player.GetComponent<Animator> ().GetBool ("RotatedUp") == true) {
				player.GetComponent<Animator> ().SetBool ("RotatedUp", false);
				player.GetComponent<Animator> ().Play ("MainGame_TarCar_RotateToDown");
			} else {
				player.GetComponent<Animator> ().SetBool ("RotatedUp", true);
				player.GetComponent<Animator> ().Play ("MainGame_TarCar_RotateToUp");
				
			}
			break;

	}
	}
	void OnMouseUp(){
		if (MainGameManager.current_game_state == MainGameManager.game_state.GameOver && MainGameManager.canReset == true) {
			MainGameManager.Start_New();
		}
	}
}

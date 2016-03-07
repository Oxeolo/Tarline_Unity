using UnityEngine;
using System.Collections;

public class MainGameLineHandler : MonoBehaviour {
	private bool beenDestroyed = false;
	public bool containsObstacle = false;
	private bool hasTried = false;
	public static float buffer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (gameObject.transform.position.x > MainGameManager.player.transform.position.x + MainGameManager.minimum_spacing_between_obstacles && containsObstacle == false && hasTried == false && MainGameManager.current_game_state == MainGameManager.game_state.Playing && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MainGame_LineSegment_GrowEnter") == false) {
		if(hasTried == false){	
			containsObstacle = MainGameManager.Generate_Obstacle(gameObject);
			hasTried = true;
			if(containsObstacle == true){
			}

		}
		//error check the booleans
		if (gameObject.transform.position.x < MainGameManager.player.transform.position.x - MainGameManager.player.GetComponent<SpriteRenderer> ().bounds.size.x / 2) {
			if(beenDestroyed == false){

				if (containsObstacle == false) {
					gameObject.GetComponent<Animator>().Play("MainGame_LineSegment_SemiShrinkExit");
				}else{
					gameObject.GetComponent<Animator>().Play("MainGame_LineSegment_NoShrinkExit");
				}
				MainGameManager.Number_Of_Line_Segments -= 1;
				MainGameManager.All_Lines.RemoveAt(0);

				//refresh names
				for(int x = 0;x< MainGameManager.Number_Of_Line_Segments;x++){
					GameObject temp = MainGameManager.All_Lines[x] as GameObject;
					temp.name = "LS_" + x;
				}

				beenDestroyed = true;
			}
			if (gameObject.transform.position.x < Camera.main.transform.position.x - MainGameManager.cameraSize.x/2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2){
				DestroyImmediate(gameObject);
				Camera.main.GetComponent<MainGameManager>().AddLineSegments(true);
			}

		}
	}


}

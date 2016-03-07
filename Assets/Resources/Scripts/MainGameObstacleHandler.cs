using UnityEngine;
using System.Collections;

public class MainGameObstacleHandler : MonoBehaviour {
	public bool beenDestroyed = false;
	public bool forceDestroy = false;
	// Use this for initialization
	void Start () {
		MainGameManager.last_obstacle_right = (float)(gameObject.transform.position.x + gameObject.GetComponentInChildren<SpriteRenderer> ().bounds.size.x / 2);
		MainGameManager.current_potential_space = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((beenDestroyed == false && gameObject.transform.position.x < Camera.main.transform.position.x - MainGameManager.cameraSize.x/2 - gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x/2)||forceDestroy == true){
			MainGameManager.Number_Of_Obstacles -= 1;
			MainGameManager.All_Obstacles.RemoveAt(MainGameManager.All_Obstacles.IndexOf(gameObject));
			DestroyImmediate(gameObject);
			//MainGameManager.All_Obstacles.TrimToSize();
			beenDestroyed = true;
		}
	}
}

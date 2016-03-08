using UnityEngine;
using System.Collections;

public class MainGameObstacleHandler : MonoBehaviour {
	public bool beenDestroyed = false;
	public bool forceDestroy = false;
	AudioClip temp = new AudioClip();
	// Use this for initialization
	void Start () {
		MainGameManager.last_obstacle_right = (float)(gameObject.transform.position.x + gameObject.GetComponentInChildren<SpriteRenderer> ().bounds.size.x / 2);
		MainGameManager.current_potential_space = 0;
		AudioClip temp = AudioManager.Blank_Sound;
		switch (gameObject.tag) {
		case "Gear":
			temp = AudioManager.Gear_Sound;
			break;
		case "Weight":
			temp = AudioManager.Weight_Sound;
			break;
		case "Line":
			temp = AudioManager.Line_Sound;
			break;
		case "Pylon":
			temp = AudioManager.Pylon_Sound;
			break;
		case "Spikes":
			temp = AudioManager.Spike_Sound;
			break;
		case "Bump":
			temp = AudioManager.Bump_Sound;
			break;

		}
		AudioManager.Play_Audio (temp);
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

using UnityEngine;
using System.Collections;

public class MainGameOver : MonoBehaviour {
	public GameObject RightWall;
	public GameObject LeftWall;
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3(MainGameManager.cameraSize.x,MainGameManager.cameraSize.y,1f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

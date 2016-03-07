using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	SpriteRenderer logo_spriteRenderer;
	float alpha;
	float animationTime;
	float initialTime;
	// Use this for initialization
	void Start () {
		//Start a DataManager Object
		gameObject.AddComponent<DataManager> ();

		//set up the alpha effect
		logo_spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		animationTime = 1f;
		//manage saved data, will be done later


	}
	
	// Update is called once per frame
	void Update () {
		//animate the alpha fade in
		if (Time.time <= animationTime) {
			alpha = Time.time / animationTime;
			logo_spriteRenderer.color = new Color (1f, 1f, 1f, alpha);
		} else {
			if (initialTime == 0){
				initialTime = Time.time;
				alpha = 1;
			}

			Debug.Log(alpha);
			logo_spriteRenderer.color = new Color (1f, 1f, 1f, alpha);
			alpha-= animationTime/100;

			if (alpha < 0.05){
				Start_Game();
			}
		}
	}

	void Start_Game(){
		Application.LoadLevel ("StartMenu");
	}



}

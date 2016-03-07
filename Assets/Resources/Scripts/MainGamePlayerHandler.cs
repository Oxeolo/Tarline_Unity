using UnityEngine;
using System.Collections;

public class MainGamePlayerHandler : MonoBehaviour {
	enum contact_position{
		Back_Of_Back,
		Front_Of_Back,
		Back_Of_Front,
		Front_Of_Front
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		float time_from_impact = 0.000f;
		ContactPoint2D contact = coll.contacts[0];
		if (Where_On_Car (contact) == contact_position.Back_Of_Front || Where_On_Car (contact) == contact_position.Back_Of_Back) {
			 time_from_impact = Time_From_Collision(contact,Where_On_Car(contact));
		}
		//contact.collider.gameObject.GetComponent<MainGameObstacleHandler> ().forceDestroy = true;
		contact.collider.GetComponentInParent<MainGameObstacleHandler> ().forceDestroy = true;
		Instantiate (MainGameManager.destroyed_particle, contact.collider.gameObject.transform.position, new Quaternion (0f, 0f, 0f, 1f));
		MainGameManager.Game_Over (time_from_impact);
	}
	contact_position Where_On_Car(ContactPoint2D contact){
		float Back_Back = 0.92426f;
		float Front_Back = 0.69559f;
		float Back_Front = 0.29386f;
		float Front_Front = 0.0661f;
		float size_car = MainGameManager.player.GetComponent<SpriteRenderer> ().bounds.size.x;
		float distance_from_front = Mathf.Abs (MainGameManager.player.transform.position.x + MainGameManager.player.GetComponent<SpriteRenderer> ().bounds.size.x / 2 - contact.point.x);
		float distance_from_point_collision;
		float distance_ratio = distance_from_front / size_car;
		if (distance_ratio < Front_Front) {
			return contact_position.Front_Of_Front;
		}else if(distance_ratio > Front_Front && distance_ratio < Back_Front){
			return contact_position.Back_Of_Front;
		}else if(distance_ratio > Back_Front && distance_ratio < Front_Back){
			return contact_position.Front_Of_Back;
		}else{
			return contact_position.Back_Of_Back;
		}
			                                                                   

	}
	float Time_From_Collision(ContactPoint2D contact,contact_position conpos){
		float Back_Back = 0.92426f;
		float Back_Front = 0.29386f;
		float size_car = MainGameManager.player.GetComponent<SpriteRenderer> ().bounds.size.x;
		float distance_from_front = Mathf.Abs (MainGameManager.player.transform.position.x + MainGameManager.player.GetComponent<SpriteRenderer> ().bounds.size.x / 2 - contact.point.x);
		float distance_ratio = distance_from_front / size_car;
		float distance_from_collision;
		float time_from_impact;
		switch (conpos) {

		case contact_position.Back_Of_Front:
			 distance_from_collision = (contact.otherCollider.gameObject.transform.position.x + contact.otherCollider.gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2) - (MainGameManager.player.transform.position.x + size_car/2 - (Back_Front * size_car));
			 time_from_impact = distance_from_collision/MainGameManager.speed;
			return time_from_impact;
			break;
		case contact_position.Back_Of_Back:
			 distance_from_collision = contact.point.x - (MainGameManager.player.transform.position.x + size_car/2 - (Back_Back * size_car));
			 time_from_impact = distance_from_collision/MainGameManager.speed;
			return time_from_impact;
			break;
		default:
			return 0f;
			break;
		}
		
		
	}
}

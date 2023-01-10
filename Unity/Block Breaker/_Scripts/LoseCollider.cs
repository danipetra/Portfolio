using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelmanager;
	private Paddle paddle;

	void Start(){

		levelmanager	=	GameObject.FindObjectOfType<LevelManager>();
		paddle=	GameObject.FindObjectOfType<Paddle>();
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		paddle.lifes--;
		if (paddle.lifes <= 0) {
			Debug.Log ("Trigger");
			levelmanager.LoadLevel ("Loose");
		}else{
			paddle.LoseLife();
			}

	}

	void OnCollisionEnter2D(Collision2D collider){
		Debug.Log("Collision");
	}


}
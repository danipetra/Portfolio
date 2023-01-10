using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	// Use this for initialization
	SceneLoader sceneLoader	=	new SceneLoader();
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{	//onTriggerEnter controls if anything passes trought the obstacles
		//if checks that is the player
		if (other.GetComponent<Player> ()	!=	null) {
		Player.instance.MakeScore();
		}
		//Debug.Log("superato");
	}

	void OnCollisionEnter2D (Collision2D other)
	{

		Debug.Log("collision");
			sceneLoader.LoadNextScene("GameOver");
		
	}

	}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPowerUp : MonoBehaviour {


	public AudioClip PowerUp;

	private GameObject gameObject;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball	=	GameObject.FindObjectOfType<Ball>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D (Collision2D col){
		AudioSource.PlayClipAtPoint(PowerUp, transform.position);
		PowerUpHit ();

	}

	public void PowerUpHit (){
	//try to change order if it doesn't work
			ball.getPowerUp();
		//TODO change translate from destroy(gameObject)
		this.transform.Translate	(10000f,0f,0f);
	} 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour {


	public AudioClip PowerUp;


	private GameObject gameObject;
	private Paddle paddle;
	// Use this for initialization
	void Start () {
		paddle	=	GameObject.FindObjectOfType<Paddle>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint(PowerUp, transform.position);
		PowerUpHit ();

	}

	void PowerUpHit (){
	//try to change order if it doesn't work
		paddle.getPaddlePowerUp();
	//TODO change translate from destroy(gameObject)
		this.transform.Translate	(10000f,0f,0f);
	} 


}

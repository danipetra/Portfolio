using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private static	int maxCollisionsWithPowerUp	=	30;
	
	private Paddle paddle;
	private bool isBoosted	=	false;
	private int BoostCount	=	1;

	public bool started	=	false;
	public Sprite[] Balls;
	public int Damage	=	1;
	public Vector3 paddleToBallVector;





	// Use this for initialization
	void Start () {
		paddle	=	GameObject.FindObjectOfType<Paddle>();	
		paddleToBallVector	=	this.transform.position	-paddle.transform.position;	
	}
	
	// Update is called once per frame
	void Update (){
		if (!started) {
			//lock the ball relative to the paddle
			this.transform.position	= paddle.transform.position	+	paddleToBallVector;
		
			//wait for mouse input
			if (Input.GetMouseButtonDown (0)) {
				print ("click");	
				started	=	true;
				this.GetComponent<Rigidbody2D> ().velocity =	new Vector2 (2f, 10f);
			}
		}
	}


		void OnCollisionEnter2D (Collision2D collision)
	{
		if (isBoosted) {
			if (BoostCount <= maxCollisionsWithPowerUp) {
				BoostCount++;
				print(BoostCount);
			} else {
			RemovePowerUp();
				
			}
		}
			
			Vector2 tweak	=	new Vector2	(Random.Range(0f,0.2f),	Random.Range(0f,0.2f));
			this.GetComponent<Rigidbody2D>().velocity	+=	tweak;
			if (started) {
				GetComponent<AudioSource> ().Play ();
				
			}
		}

		public void getPowerUp(){
		this.GetComponent<SpriteRenderer>().sprite	=	Balls[1];
		this.Damage	=	3;
		this.isBoosted	=	true;
			}

		void RemovePowerUp (){
			this.isBoosted	=	false;
			this.Damage	=	1;
			this.GetComponent<SpriteRenderer>().sprite	=	Balls[0];
		}


}


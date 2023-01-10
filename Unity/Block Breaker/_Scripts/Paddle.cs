using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private static	int maxCollisionsWithPowerUp	=	10;

	public bool autoPlaying	=	false;
	public Sprite[] spriteList;
	//public Sprite[] LifesSprite;
	public float minX;
	public float maxX;
	public int lifes	=	3;

	private Ball ball;
	private bool isBoosted	=	false;
	private int BoostCount	=	1;


	// Use this for initialization
	void Start () {
		ball	=	GameObject.FindObjectOfType<Ball>(); 
		}
	
	// Update is called once per frame
	void Update (){
		if (!autoPlaying) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}


		void OnCollisionEnter2D (Collision2D collision)
	{
		if (isBoosted) {
			if (BoostCount <= maxCollisionsWithPowerUp) {
				BoostCount++;
				print (BoostCount);
			} else {
				ResetPaddle();
				
			}
		}
	}

	void MoveWithMouse (){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y,	0);
		float MousePosInBlocks;
		MousePosInBlocks	=	(Input.mousePosition.x / Screen.width * 16);
		paddlePos.x =	Mathf.Clamp (MousePosInBlocks, minX, maxX);
		this.transform.position	=	paddlePos;
	}

	void AutoPlay ()
	{
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y,	0);
		Vector3 ballPosition;
		ballPosition	=	ball.transform.position;
		paddlePos.x =	Mathf.Clamp (ballPosition.x, minX, maxX);
		this.transform.position	=	paddlePos;
	}

	public void getPaddlePowerUp (){
			isBoosted	=	true;
			LoadLargerPaddle ();
			UpdateCollider();
			minX	=	0.88f;
			maxX	=	15.14f;
	}

	public void ResetPaddle(){
			isBoosted	=	false;		
			LoadShorterPaddle ();
			UpdateCollider();
			minX	=	0.66f;
			maxX	=	15.34f;
	}



	void LoadLargerPaddle (){
	//you can add variables to improve the handling of the array
		if (spriteList [1]	!=	null) {
			this.GetComponent<SpriteRenderer> ().sprite =	spriteList [1];
		}else{
		Debug.LogError("SPRITE MISSING");
		}
	}



	//destroying and re-creating a collider Game will lower overall Perfomance FIND A BETTER METHOD!
	void UpdateCollider ()
	{ 
		Destroy(gameObject.GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}

	public void LoseLife ()
	{
		ball.started	=	false;	
		//TODO remove a sprite of a life
	}

	void LoadShorterPaddle (){
		//you can add variables to improve the handling of the array
		if (spriteList [0]	!=	null) {
			this.GetComponent<SpriteRenderer> ().sprite =	spriteList [0];
		}else{
		Debug.LogError("SPRITE MISSING");
		}
	}



}

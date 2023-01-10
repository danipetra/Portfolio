using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int breakableCounter	=	0;
	public Sprite[] spriteList;
	public AudioClip crack;
	public GameObject crashEffect;
	public int life;

	private int DamageTaken;
	private Ball ball;
	private LevelManager levelmanager;
	private bool isBreakable;

	void Start ()
	{
		levelmanager	=	GameObject.FindObjectOfType<LevelManager> ();
		ball=	GameObject.FindObjectOfType<Ball>();
		DamageTaken	=	0;
		isBreakable	=	(this.tag	==	"Breakable");
		//keeps track of every breakable brick
		if (isBreakable) {
			breakableCounter++;
			Debug.Log (breakableCounter);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits (){
		
		DamageTaken+=	ball.Damage;
		life	=	spriteList.Length	+1;
		if (DamageTaken	>=	life) {
			breakableCounter--;
			levelmanager.BricksDestroyed();
			CreateParticleEffect();
			Destroy (gameObject);

		} else {
		LoadSprites();
		}
	}

	void CreateParticleEffect (){
		var particleEffect	=	Instantiate	(crashEffect, gameObject.transform.position,	Quaternion.identity);
		var effect	=	particleEffect.GetComponent<ParticleSystem> ().main;
		effect.startColor	=	GetComponent<SpriteRenderer> ().color;
	}

	//TODO remove this function once you can win
	void SimulateWin(){
	levelmanager.loadNextLevel();
	}

	void LoadSprites (){
		int spriteIndex;
		//gives the correct sprite index of the next sprite, check it in ispector->size
		spriteIndex	=	DamageTaken	- 1;
		if (spriteList [spriteIndex]	!=	null) {
			this.GetComponent<SpriteRenderer> ().sprite =	spriteList [spriteIndex];
		}else{
		Debug.LogError("SPRITE MISSING");
		}
	}

}
 
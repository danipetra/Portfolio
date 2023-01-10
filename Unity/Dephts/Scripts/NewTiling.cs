using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent	(typeof(SpriteRenderer))]

public class NewTiling : MonoBehaviour {

	public int offsetY	=	2;
	public bool	reverseScale	=	false;

	private bool hasDownBuddy	=	false;
	private float spriteHeight	=	0f;
	private Camera cam;
	private Transform myTransform;

	void Awake (){
		cam	=	Camera.main;
		myTransform	=	transform;
	}
	// Use this for initimyTransform
	void Start () {
		SpriteRenderer sRenderer	=	GetComponent<SpriteRenderer>();
		spriteHeight	=	sRenderer.sprite.bounds.size.y;


		
	}
	
	// Update is calledmyTransform frame
	void Update ()
	{
		
		if (hasDownBuddy	==	false) {
			
			float camVerticalExtend	=	cam.orthographicSize	*	Screen.height	/	Screen.width;
			float edgeVisiblePositionDown	=	(myTransform.position.y	+	spriteHeight	/ 2)	-	camVerticalExtend;

			if (cam.transform.position.y	<=	edgeVisiblePositionDown	-	offsetY	&&	hasDownBuddy	==	false) {
				MakeNewBuddy(1.0f);//fixare generazione background 1.1 troppo in basso, sembra migliorare con 0.65
				hasDownBuddy	=	true;
			}	
		}
	}

	void MakeNewBuddy (float position){

		Vector3	newBuddyPosition	=	new Vector3 (myTransform.position.x, myTransform.position.y	-	spriteHeight	*	position,	myTransform.position.z);

		Transform newBuddy	=	(Transform)Instantiate (myTransform,	newBuddyPosition,	myTransform.rotation);
		//reverse the x size of the object to make it tilable
		if (reverseScale	==	true) {
			newBuddy.localScale	=	new Vector3 (newBuddy.localScale.x,	newBuddy.localScale.y	*	-1,	newBuddy.localScale.z);
		}

		newBuddy.parent	=	myTransform.parent;

		if (position	<	0) {
			
			newBuddy.GetComponent<NewTiling>().hasDownBuddy	=	true;
		}

	}


}

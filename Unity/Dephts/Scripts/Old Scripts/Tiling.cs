using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent	(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {

	public int offsetX	=	2;
	public bool hasRightBuddy	=	false;//!
	public	bool	hasLeftBuddy	=	false;//!
	public bool	reverseScale	=	false;

	private float spriteWidht	=	0f;
	private Camera cam;
	private Transform myTransform;

	void Awake (){
		cam	=	Camera.main;
		myTransform	=	transform;
	}
	// Use this for initimyTransform
	void Start () {
		SpriteRenderer sRenderer	=	GetComponent<SpriteRenderer>();
		spriteWidht	=	sRenderer.sprite.bounds.size.x;//!


		
	}
	
	// Update is calledmyTransform frame
	void Update ()
	{
		if (hasLeftBuddy	==	false	||	hasRightBuddy	==	false) {
			//!
			float camHorizontalExtend	=	cam.orthographicSize	*	Screen.width	/	Screen.height;
			float edgeVisiblePositionRight	=	(myTransform.position.x	+	spriteWidht	/ 2)	-	camHorizontalExtend;
			float edgeVisiblePositionLeft	=	(myTransform.position.x	-	spriteWidht	/ 2)	+	camHorizontalExtend;

			if (cam.transform.position.x	>=	edgeVisiblePositionRight	-	offsetX	&&	hasRightBuddy	==	false) {
				MakeNewBuddy(1);
				hasRightBuddy	=	true;
			} else if (cam.transform.position.x	<=	edgeVisiblePositionLeft	+	offsetX	&&	hasLeftBuddy	==	false) {
				MakeNewBuddy(-1);
				hasLeftBuddy	=	true;
			}		

		}
	}

	void MakeNewBuddy (int rightOrLeft){

		Vector3	newBuddyPosition	=	new Vector3 (myTransform.position.x	+	spriteWidht	*	rightOrLeft, myTransform.position.y,	myTransform.position.z);

		Transform newBuddy	=	(Transform)Instantiate (myTransform,	newBuddyPosition,	myTransform.rotation);
		//reverse the x size of the object to make it tilable
		if (reverseScale	==	true) {
			newBuddy.localScale	=	new Vector3 (newBuddy.localScale.x	*	-1,	newBuddy.localScale.y,	newBuddy.localScale.z);
		}

		newBuddy.parent	=	myTransform.parent;

		if (rightOrLeft	>	0) {
			newBuddy.GetComponent<Tiling> ().hasLeftBuddy	=	true;
			
		} else {
			newBuddy.GetComponent<Tiling>().hasRightBuddy	=	true;
		}

	}


}

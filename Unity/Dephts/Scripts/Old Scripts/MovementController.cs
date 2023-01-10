using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float	moveSpeed=300;
	public GameObject	player;

	private Rigidbody2D	playerBody;
	private float screenWidht;

	void Start () {
		screenWidht	=	Screen.width;
		playerBody	=	player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckTouches();
	}

	void FixedUpdate ()
	{	
		#if UNITY_EDITOR
		MovePlayer(Input.GetAxis("Horizontal"));
		#endif
	}

	private void MovePlayer(float horizontalInput){

		playerBody.AddForce(new Vector2(horizontalInput	*	moveSpeed	*	Time.deltaTime,0));

	}

	private void CheckTouches ()
	{	
		int i = 0;
		if (Input.touchCount > 0) {

			foreach (Touch touch in Input.touches) {
				if (Input.GetTouch(i).position.x	>	screenWidht / 2) {
					MovePlayer (1.0f);
				}
				if (Input.GetTouch(i).position.x	<	screenWidht / 2) {
					MovePlayer (-1.0f);
				}
		
			}
		}
	}
		

}

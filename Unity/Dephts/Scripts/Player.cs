using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour {

	public float moveSpeed	=	450.0f;
	public Text scoreText;
	public static Player instance;

	private float screenWidht;
	private int score	=	0;
	private Rigidbody2D playerBody;
	private bool	GameOver	=	false;

	void Awake()
    {
        //If we don't currently have a Player...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }


	// Use this for initialization
	void Start () {

		screenWidht	=	Screen.width;
		playerBody	=	this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		CheckTouches();
	}

	void FixedUpdate ()
	{	
		#if UNITY_EDITOR
		Move(Input.GetAxis("Horizontal"));
		#endif
	}

	private void Move(float horizontalInput){

		playerBody.AddForce(new Vector2(horizontalInput	*	moveSpeed	*	Time.deltaTime,0));

	}

	private void CheckTouches ()
	{	
		int i = 0;
		if (Input.touchCount > 0) {

			foreach (Touch touch in Input.touches) {
				if (Input.GetTouch(i).position.x	>	screenWidht / 2) {
					Move (1.0f);
				}
				if (Input.GetTouch(i).position.x	<	screenWidht / 2) {
					Move (-1.0f);
				}
		
			}
		}
	}

	public void MakeScore ()
	{	
		score++;
		scoreText.text	=	"Score: "	+	score.ToString();
			
		
	}
}

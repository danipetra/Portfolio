using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	private Paddle paddle;
	// Use this for initialization

	private void Start ()
	{
		paddle	=	GameObject.FindObjectOfType<Paddle> ();
	}


	public void LoadLevel (string name) {
	Brick.breakableCounter	=	0;
	Debug.Log("loadlevel request for: "+name);
	Application.LoadLevel(name);
	//you can delete this
	//paddle.ResetPaddleDimensions();
	}

	public void loadNextLevel(){
	Brick.breakableCounter	=	0;
	Application.LoadLevel(Application.loadedLevel	+1);
	//you can delete this
	//paddle.ResetPaddleDimensions();
	}


	public void BricksDestroyed ()
	{
		if (Brick.breakableCounter	<=	0) {
			loadNextLevel ();
		}
	}

	public void QuitRequest () {
		Debug.Log("QuitRequest");

	}
		
}

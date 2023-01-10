using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log("Request to Quit");
			Application.Quit();
		}
	}


	public void LoadNextScene ()
	{	
		int currentSceneIndex	=	SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex	+1	);
	}

	public void LoadNextScene (string name)
	{
	Debug.Log("loadlevel request for: "+name);
	SceneManager.LoadScene(name);
	}

	public void QuitGame ()
	{
		Debug.Log("Request to Quit");
		Application.Quit();
	}
}

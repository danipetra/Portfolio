using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	public static MusicPlayer music=null;

	void Awake(){
	 	Debug.Log("Music player is awake"	+GetInstanceID());
		//se è stato già creato (awake) terminae una nuova istanza del music player prima di 
		//il problema nasce quando ritorno nel menu start e inizio una nuova partita
		if(music != null){
			Destroy(gameObject);
			print("destructing duplicate of music before starting it"+GetInstanceID());
		}else{
		//crea un'istanza statica della classe stessa, ciò fa si che si possa creare un SOLO MUSIC PLAYER
			music	=	this;
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Music player starts"	+GetInstanceID());
		//per riprodurre la musica anche dopo aver caricato una scena nuova
		//GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

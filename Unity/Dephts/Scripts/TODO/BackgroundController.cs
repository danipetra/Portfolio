using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public SpriteRenderer renderer1	=	new SpriteRenderer();
	GameObject player =	new GameObject();

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SelectRandomBackground ()
	{
	//da usare nello start per selezionare un set di sprites di backround random, NELLA START
	}

	public void ChangeBackgroundColor ()
	{
			
		//quando raggiungi un certo punteggio o usa deltatime cambia gradualmente il colore del background
	}
}

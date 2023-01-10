using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColumnsPool : MonoBehaviour {

	public int columnPoolSize	=	5;
	public GameObject ColumnPrefab;
	public float spawnRate	=	0.9f;
	public float columnMin	=	-5.0f; //ideali: 5 e -5
	public float columnMax	=	5.0f; //

	public float spawnXPosition	=	0.0f;
	private GameObject[] columns;
	private Vector2 objectPoolPosition	=	new Vector2(0f,25f);
	private float timeSinceLastSpawned	=	0f;
	private float spawnYPosition	= -10.5f; //
	private int currentColumn	=	0;
	// Use this for initialization
	void Start ()
	{
		columns	=	new GameObject[columnPoolSize];
		for (int i=0;	i <	columnPoolSize;	i++) {
			columns[i]	=	(GameObject)Instantiate(ColumnPrefab,objectPoolPosition, Quaternion.identity);
			columns [i].transform.parent	=	ColumnPrefab.transform.parent;//AGGIUNTO
			}
	}
	
	// Update is called once per frame
	void Update ()
	{

		timeSinceLastSpawned	+=	Time.deltaTime;
		if (SceneManager.GetActiveScene ().name == "Game"	&&	timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned	=	0f;

			if(spawnXPosition>=columnMin && spawnXPosition<columnMin/2){
				spawnXPosition	=	Random.Range (columnMin, columnMin + columnMax);//
			}
			else if(spawnXPosition>=columnMin/2 && spawnXPosition<	columnMin+columnMax){
				spawnXPosition	=	Random.Range (columnMin, columnMax	/2);//
			}
			else if(spawnXPosition>=columnMin+columnMax && spawnXPosition< columnMax	/	2){
				spawnXPosition	=	Random.Range (columnMin/	2, columnMax);//
			}
			else if(spawnXPosition>=columnMax/2 && spawnXPosition<columnMax){
				spawnXPosition	=	Random.Range (columnMin	+ columnMax, columnMax);//
			}


			float spawnZPosition	=	-10.0f;
			columns [currentColumn].transform.position	=	new Vector3 (spawnXPosition,	spawnYPosition,	spawnZPosition);
			columns [currentColumn].transform.parent	=	ColumnPrefab.transform.parent;//AGGIUNTO
			Debug.Log("obstacle created"+currentColumn);
			currentColumn++;
			if (currentColumn	>=	columnPoolSize) {
				currentColumn	=	0;
			}
		}

	}

		
	
}

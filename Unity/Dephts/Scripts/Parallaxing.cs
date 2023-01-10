using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float parallaxingAmount	=	1f;	//how smooth the parallaxing will be
	private Transform camera;
	private Vector3	previousFrameCamPosition;

	//called before start
	void Awake ()
	{	
		camera	=	Camera.main.transform;
	}

	// Use this for initialization
	void Start ()
	{
		previousFrameCamPosition	=	camera.position;
		parallaxScales	=	new float[backgrounds.Length];

		for (int i = 0;	i < backgrounds.Length;	i++) {

			parallaxScales[i]	=	backgrounds[i].position.z*	-	1;	

		}


		
	}
	
	// Update is called once per frame
	void Update ()
	{

		for (int i = 0;	i < backgrounds.Length;	i++) {

			float parallax	=	(previousFrameCamPosition.y	-	camera.position.y	+	parallaxScales[i]);
			float backgroundTargetPositionY	=	backgrounds[i].position.y	+	parallax;
			Vector3	backgroundTargetPosition	=	new Vector3	(backgrounds[i].position.x,	backgroundTargetPositionY,	backgrounds[i].position.z);
			backgrounds[i].position	=	Vector3.Lerp	(backgrounds[i].position,	backgroundTargetPosition, parallaxingAmount	*	Time.deltaTime);

		}

		previousFrameCamPosition	=	camera.position;
	}
}

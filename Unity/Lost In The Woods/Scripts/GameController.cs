using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform platformGeneratorTransform;
    public GameObject[] characters;

    private GameObject player;
    private Vector3 playerStartPoint;
    public float playerDistanceFromGround = 1f;

    public GameObject camera;

    private Vector3 platformGeneratorStartPoint;


    private CoinManager scoreManager;

    private void Awake()
    {
        playerStartPoint = new Vector3(transform.position.x, transform.position.y + playerDistanceFromGround, transform.position.z);
        GameObject player = Instantiate(characters[PlayerPrefs.GetInt("Selected Character")], playerStartPoint, Quaternion.identity);
        player.name = "Player";
        player.SetActive(true);

        camera.GetComponent<CameraFollow>().Player = player;
    }

    void Start()
    {
        scoreManager = FindObjectOfType<CoinManager>();
        
    }


    void Update()
    {

    }

   /* private void getStartGameInfo()
    {
        playerStartPoint = player.transform.position;
        platformGeneratorStartPoint = platformGeneratorTransform.position;
    }*/

    public void GameOver()
    {
        scoreManager.totalCoinsIncreasing = false;
        scoreManager.saveCoinsGrabbedOnLastRound();

        GetComponent<SceneLoader>().LoadScene("GameoverScene");
        scoreManager.totalCoinsIncreasing = true;
    }

    private void loadCharacter()
    {
        //todo
    }

}




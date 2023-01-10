using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Range(0, 3)]
    public int lives = 1;

    [Range(5, 12)]
    public float moveSpeed = 10f;
    private bool isPlaying = true;
    [Range(1.0f, 1.05f)]
    public float speedMultiplier = 1.05f;
    [Range(100f, 500f)]
    public float speedIncreaseXCoordinate = 100.0f;
    private float speedMilestoneCount;




    [Range(10.0f, 70.0f)]
    public float jumpForce = 8f;
    public float maxHoldJumpTime = 0.3f;
    [Range(5.0f, 15.0f)]
    public float gravityIncreaseAfterJump = 15f;
    private float holdJumpTimer = 0.0f;
    private bool isHoldingJump = false;
    private float defaultGravity;

    
    public LayerMask WhatIsGround;
    public GameController GameController;

    private Rigidbody2D myRigidBody;
    private CircleCollider2D myFeet;
    private BoxCollider2D myCollider;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "CharacterMenu")
        {
            isPlaying = false;
        }
    }
    void Start()
    {

            myRigidBody = GetComponent<Rigidbody2D>();
            myCollider = GetComponent<BoxCollider2D>();
            myFeet = GetComponentInChildren<CircleCollider2D>();

            defaultGravity = myRigidBody.gravityScale;
            speedMilestoneCount = speedIncreaseXCoordinate;

    }


    void Update()
    {
        ResetGravityAfterJumping();
        Move();
        CheckPlayerTouches();
            
    }

    private void Move()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseXCoordinate;
            //milestone for each speed increase
            speedIncreaseXCoordinate *= speedMultiplier;
            moveSpeed *= speedMultiplier;
        }

    }

    private void CheckPlayerTouches()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            
            if(touch.position.x <= Screen.width)
            {
                Jump(touch);
            }

            else
            {
                changeGravity();
            }

        }
    }

    private void Jump(Touch jumpTouch)
    {
        if (IsTouchingTheGround())
        {
            //Check screen y coordinate here, to add more skills(use other functions)


            //Declare doubleJumpTouch here!

            //player is jumping
            if (jumpTouch.phase == TouchPhase.Began)
            {
                myRigidBody.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void changeGravity()
    {
        
    }

    //function used before to make jumps proportional to touch time
    private void proportionalJump()
    {
        if (IsTouchingTheGround())
        {
            //Check screen y coordinate here, to add more skills(use other functions)
            Touch jumpTouch = Input.touches[0];

            //Declare doubleJumpTouch here!

            //player is jumping
            if (jumpTouch.phase != TouchPhase.Canceled && jumpTouch.phase != TouchPhase.Ended)
            {
                myRigidBody.velocity = Vector2.up * jumpForce;

                isHoldingJump = true;
                //holdJumpTimer = 0;

            }
            //player ended the jump
            else
            {
                isHoldingJump = false;
                //depending on huldjumptimer apply falling force
                myRigidBody.gravityScale /= holdJumpTimer * 10;
                holdJumpTimer = 0;
            }

            if (!IsTouchingTheGround())
            {
                if (isHoldingJump)
                {
                    holdJumpTimer += Time.deltaTime;

                    if (holdJumpTimer >= maxHoldJumpTime)
                    {
                        isHoldingJump = false;
                    }
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Killbox")
        {
            GameController.GameOver();
        }

        if (other.gameObject.tag == "Obstacle")
        {
            if (lives > 1)
            {
                lives--;
                //deactivate player collider for 0.5 secs DONE TEST it and make a visual feedback
            }
            else if (lives <= 1)
            {
                GameController.GameOver();
            }
        }
    }

    public bool IsTouchingTheGround()
    {
        if (Physics2D.IsTouchingLayers(myFeet, WhatIsGround))
        {
            return true;
        }
        return false;

    }

   
    

    private void ResetGravityAfterJumping()
    {
        if (IsTouchingTheGround())
        {
            if (myRigidBody.gravityScale != defaultGravity)
            {
                myRigidBody.gravityScale = defaultGravity;
            }
        }
    }

    private void becomeInvulnerable(float invulnerabilityTime)
    {
        StartCoroutine(becomeInvulnerableCO(invulnerabilityTime));
    }

    private IEnumerator becomeInvulnerableCO(float invulnerabilityTime)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(invulnerabilityTime); //waits half a second before restarting

        GetComponent<BoxCollider2D>().enabled = true;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float health;

    public float speed =50f, yawSpeed = 15f, pitchSpeed = 20f; //rotation on the x axis
    private float activeYawSpeed, activePitchSpeed;

    
    private float shipRotationAngle = 45f;
    [SerializeField]
    private Weapon weaponScript;
    private Transform myTransform;
    private ArrayList myColliders;
    private Rigidbody myRigidBody;
    private Quaternion targetRotation;

    protected void Awake()
    {
        getTransform();
        getRigidBody();
        getColliders();
        getWeapon();
    }
    protected void getRigidBody()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>();

        if (!myRigidBody)
        {
            Debug.LogError("rigid body not found");
        }
    }

    protected void getWeapon()
    {
         weaponScript = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();

        if (!weaponScript)
        {
            Debug.LogError("You Don't have a weapon");
        }
    }
    
   
    protected void getTransform()
    {
        myTransform = GetComponent<Transform>();

        if (!myTransform)
        {
            Debug.LogError("transform not found");
        }
    }

    protected void getColliders()
    {
        Debug.Log("program getColliders Function!");
    }

    protected void getWeapons() {/*to implement in the future if you'll have multyple weapons*/ }

    protected void move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected void turn(Vector2 direction)
    {


        activeYawSpeed = yawSpeed * Time.deltaTime * direction.x;
        activePitchSpeed = pitchSpeed * Time.deltaTime * direction.y;

        /*if(activeRollSpeed >= -maxRoll && activeRollSpeed <= maxRoll)
        {
            activeRollSpeed = rollSpeed * Time.deltaTime * activePitchSpeed;
        }*/
        

        targetRotation = Quaternion.LookRotation(direction);

        //add a z "cinematic" rotation
        myTransform.Rotate(-activePitchSpeed, activeYawSpeed,0);
        //myTransform.Rotate used before
    }

    
    public void shoot()
    {
        weaponScript.fireBullet();
    }

    
}

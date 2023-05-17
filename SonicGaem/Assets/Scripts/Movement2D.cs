using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public Rigidbody player; 
    public float movementspeed = 5000f;
    public bool isgrounded;
    private float jumpheight = 50000f;
    public GameObject feet;
    LayerMask groundMask;
    private bool isstandingstill;
    private float spindashSpeed = 90000f;
    private bool chargingSpinDash;
    public bool rolling;
    private bool facingLeft;
    private bool facingRight;

    public CameraScript cameracript; 

    public bool useGravity = true; 

    public AudioSource jumpSound;
    public AudioSource SpinSoundEnd;
    public AudioSource SpinDashSound; 

   

    

    // Start is called before the first frame update
    void Start()
    {
        isgrounded = true;
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame

   

    void Update()
    {

        // RegularMovement 
        if (Input.GetKey(KeyCode.D))
        {
            player.AddRelativeForce(Vector3.left  * movementspeed * Time.deltaTime, ForceMode.Force);
            facingRight = true;
            facingLeft = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddRelativeForce(Vector3.left * -movementspeed * Time.deltaTime, ForceMode.Force);
            facingRight = false;
            facingLeft = true;

        }
        if (Input.GetKey(KeyCode.Space) && isgrounded)
        {
            player.AddRelativeForce(Vector3.up * jumpheight * Time.deltaTime);
            jumpSound.Play();

        }
        // GroundAlignment 
       isgrounded = Physics.CheckSphere(feet.transform.position, 0.2f, groundMask);

        GetAlignment();

        //Spindash 
        if (player.velocity.magnitude < 0.2f)
        {
            isstandingstill = true;
            Debug.Log("Still");
        }
        else
        {
            isstandingstill = false;
            Debug.Log("Moving");
        }
        //Rolling
        if (Input.GetKeyDown(KeyCode.S) && isstandingstill == false && isgrounded)
        {
            SpinDashSound.Play();

            

        }
        if (Input.GetKey(KeyCode.S) && isstandingstill == false && isgrounded)
        {
            rolling = true;
            Debug.Log("Rolling");
            movementspeed = 0.0f;
            
            player.freezeRotation = false;
  
        }
        else
        {
            rolling = false;
            movementspeed = 5000f;
            
            player.freezeRotation = true;
        }
              
        if(Input.GetKey(KeyCode.S) && isstandingstill && Input.GetKeyDown(KeyCode.LeftShift))
        {
            chargingSpinDash = true;
            SpinDashSound.Play();
        }
        
        if(Input.GetKey(KeyCode.LeftShift) && chargingSpinDash && isstandingstill && facingRight)
        {
            player.AddRelativeForce(Vector3.left * spindashSpeed * Time.deltaTime, ForceMode.Acceleration);
            SpinSoundEnd.Play();
            player.drag = 0;
            rolling = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && chargingSpinDash && isstandingstill && facingLeft)
        {
            player.AddRelativeForce(Vector3.right * spindashSpeed * Time.deltaTime, ForceMode.Acceleration);
            SpinSoundEnd.Play();
            player.drag = 0;
            rolling = true;
        }


        if (isgrounded == false)
        {
            movementspeed = 5000f / 2;
            
        }
        else
        {
            movementspeed = 5000f;
            player.AddRelativeForce(Vector3.up * -500f * Time.deltaTime, ForceMode.Acceleration);
        }
        

        

    }
    private void FixedUpdate()
    {
        player.useGravity = false;
        if (useGravity) player.AddForce(Physics.gravity * (player.mass * player.mass)); 
    }

    void GetAlignment()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit, 1.2f, groundMask);

        Vector3 newUp = hit.normal;

        transform.up = newUp; 

    }
    
}

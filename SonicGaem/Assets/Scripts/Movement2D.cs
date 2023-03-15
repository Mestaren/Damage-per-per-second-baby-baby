using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public Rigidbody player; 
    private float movementspeed = 5000f;
    private bool isgrounded;
    private float jumpheight = 50000f;
    public GameObject feet;
    LayerMask groundMask;
    private bool isstandingstill;
    private float spindashSpeed = 700000f;
    private bool chargingSpinDash;
    private bool rolling;

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
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddRelativeForce(Vector3.left * -movementspeed * Time.deltaTime, ForceMode.Force);

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
            player.angularDrag = 0.0f;
            player.drag = 0.0f; 
  
        }
        else
        {
            rolling = false;
            movementspeed = 5000f;
            player.angularDrag = 0.05f;
            player.drag = 0.5f; 
        }
              
        if(Input.GetKey(KeyCode.S) && isstandingstill && Input.GetKeyDown(KeyCode.LeftShift))
        {
            chargingSpinDash = true;
            SpinDashSound.Play();
        }
        
        if(Input.GetKey(KeyCode.LeftShift) && chargingSpinDash && isstandingstill)
        {
            player.AddRelativeForce(Vector3.left * spindashSpeed * Time.deltaTime, ForceMode.Force);
            SpinSoundEnd.Play();
            player.drag = 0; 
        }
        

        if (isgrounded == false)
        {
            movementspeed = 5000f / 2; 
        }
        else
        {
            movementspeed = 5000f; 
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

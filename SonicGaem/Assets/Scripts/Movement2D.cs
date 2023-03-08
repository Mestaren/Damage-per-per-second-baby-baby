using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public Rigidbody player; 
    private float movementspeed = 50f;
    private bool isgrounded;
    private float jumpheight = 100f;
    public GameObject feet;
    LayerMask groundMask;
    private bool isstandingstill;
    private float spindashSpeed = 100000/2f;
    private bool chargingSpinDash; 

    

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
            player.AddRelativeForce(Vector3.left * movementspeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddRelativeForce(Vector3.left * -movementspeed);

        }
        if (Input.GetKey(KeyCode.Space) && isgrounded)
        {
            player.AddRelativeForce(Vector3.up * jumpheight); 
        }
        // GroundAlignment 
       isgrounded = Physics.CheckSphere(feet.transform.position, 0.2f, groundMask);

        GetAlignment();

        //Spindash 
        if (player.velocity.magnitude == 0.0f)
        {
            isstandingstill = true;
            Debug.Log("Still");
        }
        else
        {
            isstandingstill = false;
            Debug.Log("Moving");
        }

        if(Input.GetKey(KeyCode.S) && isstandingstill && Input.GetKeyDown(KeyCode.LeftShift))
        {
            chargingSpinDash = true; 
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift) && chargingSpinDash && isstandingstill)
        {
            player.AddRelativeForce(Vector3.left * spindashSpeed);
        }
    }
    void GetAlignment()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit, 1.2f, groundMask);

        Vector3 newUp = hit.normal;

        transform.up = newUp; 

    }
}

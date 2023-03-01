using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{

    public Rigidbody player; 
    private float movementspeed = 5f;
    private bool isgrounded;
    private float jumpheight = 10f;
    public GameObject feet;
    LayerMask groundMask;

    

    // Start is called before the first frame update
    void Start()
    {
        isgrounded = true;
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame

   

    void Update()
    {
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
       isgrounded = Physics.CheckSphere(feet.transform.position, 0.2f, groundMask);

        GetAlignment(); 
    }
    void GetAlignment()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit, 0.7f, groundMask);

        Vector3 newUp = hit.normal;

        transform.up = newUp; 

    }
}

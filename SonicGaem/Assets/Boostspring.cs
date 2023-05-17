using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostspring : MonoBehaviour
{
    public Movement2D movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spring"))
        {
            

            movement.player.AddRelativeForce(Vector3.up * 250000f * Time.deltaTime);
            movement.movementspeed = 0f;

            Debug.Log("SpringBoing");

        }




    }
}

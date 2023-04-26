using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : MonoBehaviour
{
    public float sphereRadius = 5f;
    public Rigidbody player;
    public LayerMask mask;


    void Update()
    {
        if(Physics.CheckSphere(transform.position, sphereRadius, mask))
        {
            Debug.Log("HasEntered");
            player.MoveRotation(Quaternion.Euler(0, 90, 0));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}

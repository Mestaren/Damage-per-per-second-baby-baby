using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class platformMove : MonoBehaviour
{

    public float moveSpeed = 5.0f; // Hastighet att åka framåt med
    public float raycastDistance = 2.0f; // Längd av raycast-strålen
    public LayerMask Ground; // Lagret för "Ground"-objektet

    private bool movingForward = true; // Boolesk variabel som håller koll på om objektet rör sig framåt

    void Update()
    {
        // Rörelse i framåtriktning
        if (movingForward)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else // Rörelse i bakåtriktning
        {
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Utför raycast för att detektera "Ground"-objektet
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, raycastDistance, Ground))
        {
            // Om raycast träffar ett "Ground"-objekt, ändra riktning
            movingForward = !movingForward;
        }
    }
}




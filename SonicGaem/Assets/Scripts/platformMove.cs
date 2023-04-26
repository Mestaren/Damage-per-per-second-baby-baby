using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class platformMove : MonoBehaviour
{

    public float moveSpeed = 5.0f; // Hastighet att �ka fram�t med
    public float raycastDistance = 2.0f; // L�ngd av raycast-str�len
    public LayerMask Ground; // Lagret f�r "Ground"-objektet

    private bool movingForward = true; // Boolesk variabel som h�ller koll p� om objektet r�r sig fram�t

    void Update()
    {
        // R�relse i fram�triktning
        if (movingForward)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else // R�relse i bak�triktning
        {
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Utf�r raycast f�r att detektera "Ground"-objektet
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, raycastDistance, Ground))
        {
            // Om raycast tr�ffar ett "Ground"-objekt, �ndra riktning
            movingForward = !movingForward;
        }
    }
}




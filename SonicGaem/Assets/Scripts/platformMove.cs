using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class platformMove : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }
}




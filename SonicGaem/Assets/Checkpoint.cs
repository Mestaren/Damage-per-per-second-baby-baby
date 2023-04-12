using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject Trigger;
    public Animator Spin; 

    private void Start()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Spin.SetBool("New Bool", true);
        }
    }
}

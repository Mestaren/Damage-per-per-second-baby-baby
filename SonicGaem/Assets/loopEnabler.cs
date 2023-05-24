using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopEnabler : MonoBehaviour
{
    public GameObject player;
    public GameObject rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = rotationPoint.transform;
        }
    }
}

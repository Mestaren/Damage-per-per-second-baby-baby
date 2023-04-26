using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatoPotato : MonoBehaviour
{
    public GameObject feet;
    private bool isgrounded;

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
        isgrounded = Physics.CheckSphere(feet.transform.position, 0.2f, groundMask);

        GetAlignment();

        void GetAlignment()
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, -transform.up, out hit, 1.2f, groundMask);

            Vector3 newUp = hit.normal;

            transform.up = newUp;

        }
    }
}

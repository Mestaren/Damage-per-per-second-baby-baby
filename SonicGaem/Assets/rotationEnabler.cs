using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class rotationEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<rotation>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.childCount > 0)
        {
            this.GetComponent<rotation>().enabled = true;
        }
       else
        {
            this.GetComponent<rotation>().enabled = false;
        }

    }
}

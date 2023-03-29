using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float climb = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void commence(float amount)
    {
        climb -= amount;
        if(climb <= 0)
        {
            Go();
        }
    }


    void Go()
    {
        Destroy(gameObject);
    }
}

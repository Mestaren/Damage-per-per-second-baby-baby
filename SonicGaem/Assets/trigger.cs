using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trigger : MonoBehaviour
{

    [SerializeField] UnityEvent onTriggerEnter;



    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

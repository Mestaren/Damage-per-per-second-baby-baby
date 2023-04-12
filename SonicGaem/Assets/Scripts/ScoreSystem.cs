using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class ScoreSystem : MonoBehaviour
{
    public Movement2D movement;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
   private void Update()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && movement.isgrounded == false)
        {
            Destroy(other.gameObject);

            Debug.Log("EnemyDestroyed");

            movement.player.AddRelativeForce(Vector3.up * 250000f * Time.deltaTime);


        }

        

    }


}

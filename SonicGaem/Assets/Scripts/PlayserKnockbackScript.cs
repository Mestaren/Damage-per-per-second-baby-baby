using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayserKnockbackScript : MonoBehaviour
{
    private float Range = 5f;
    private float Knockbackforce = 15;
    public GameObject Player;
    LayerMask player;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRaycast();
        if(Physics.Raycast(transform.position, transform.up * Range, out hit))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                KnockBack();
            }
        }
    }

    void ShootRaycast()
    {
        Physics.Raycast(transform.position, transform.up * Range, out hit);

    }

    void KnockBack()
    {
        Player.transform.position += transform.up * Time.deltaTime * Knockbackforce;
    }
}

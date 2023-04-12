using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayserKnockbackScript : MonoBehaviour
{
    private float Range = 5f;
    private float Knockbackforce = 25;
    public GameObject Player;
    LayerMask player;
    RaycastHit hit;

    [Header("DennisBajs123")]

    public Color flashColour;
    public Color regularColour;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider triggerCollider;
    public SpriteRenderer mySprite;

    public iFrames iframe;
    
    void Start()
    {
      iframe = GetComponent<iFrames>();
    }
    void Update()
    {
        ShootRaycast();

        if(Physics.Raycast(transform.position, transform.up * Range, out hit))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                KnockBack();

                Debug.Log("ouchies");

                iframe.canGetHit = false;
            }
        }
    }

    void ShootRaycast()
    {
        Physics.Raycast(transform.position, transform.up * Range, out hit);

    }

    void KnockBack()
    {
        StartCoroutine(FlashCo());
        Player.transform.position += transform.up * Time.deltaTime * Knockbackforce;
    }

    private IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while(temp < numberOfFlashes)
        {
            mySprite.color = flashColour;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColour;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}

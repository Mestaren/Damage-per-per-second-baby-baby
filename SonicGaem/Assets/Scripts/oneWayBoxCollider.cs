using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class oneWayBoxCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("The direction that the other object should be coming from for entry.")]
    [SerializeField]
    private Vector3 entryDirection = Vector3.up;
    [Tooltip("Should the entry direction be used as a local direction?")]
    [SerializeField]
    private bool localDirection = false;
    [Tooltip("How large should the trigger be in comparison to the original collider?")]
    [SerializeField]
    private Vector3 triggerScale = Vector3.one * 1.25f;
    [Tooltip("The collision will activate only when the penetration depth of the intruder is smaller than this threshold.")]
    [SerializeField]
    private float penetrationDepthThreshold = 0.2f;

    [Tooltip("The original collider. Will always be present thanks to the RequireComponent attribute.")]
    private new BoxCollider collider = null;
    [Tooltip("The trigger that we add ourselves once the game starts up.")]
    private BoxCollider collisionCheckTrigger = null;

 
    public Vector3 PassthroughDirection => localDirection ? transform.TransformDirection(entryDirection.normalized) : entryDirection.normalized;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        collisionCheckTrigger = gameObject.AddComponent<BoxCollider>();
        collisionCheckTrigger.size = new Vector3(
            collider.size.x * triggerScale.x,
            collider.size.y * triggerScale.y,
            collider.size.z * triggerScale.z
        );
        collisionCheckTrigger.center = collider.center;
        collisionCheckTrigger.isTrigger = true;
    }

    private void OnValidate()
    {
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        TryIgnoreCollision(other);
    }

    public void TryIgnoreCollision(Collider other)
    {
        if (Physics.ComputePenetration(
            collisionCheckTrigger, collisionCheckTrigger.bounds.center, transform.rotation,
            other, other.bounds.center, other.transform.rotation,
            out Vector3 collisionDirection, out float penetrationDepth))
        {
            float dot = Vector3.Dot(PassthroughDirection, collisionDirection);

            if (dot < 0)
            {
                if (penetrationDepth < penetrationDepthThreshold)
                {
                    Physics.IgnoreCollision(collider, other, false);
                }
            }
            else
            {
                Physics.IgnoreCollision(collider, other, true);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.TransformPoint(collider.center), PassthroughDirection * 2);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.TransformPoint(collider.center), -PassthroughDirection * 2);
    }
}

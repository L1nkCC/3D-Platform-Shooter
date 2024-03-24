using JUTPS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(JUHealth),typeof(CapsuleCollider))]
public class Sufficate : MonoBehaviour
{
    CapsuleCollider c_collider;
    JUHealth c_health;

    [SerializeField]
    float chokeDistance = .1f;
    [SerializeField]
    [Tooltip("What layers should sufficate? Must exclude all layers that Player has")]
    LayerMask sufficateLayerMask;

    private void Start()
    {
        c_collider = GetComponent<CapsuleCollider>();
        c_health = GetComponent<JUHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        List<ContactPoint> contactPoints = new List<ContactPoint>();
        collision.GetContacts(contactPoints);
        foreach (ContactPoint point in contactPoints)
        {
            RaycastHit hit;
            float distance = c_collider.radius*2 + chokeDistance;
            if (Physics.Raycast(transform.TransformPoint(c_collider.center), point.normal,out hit,distance, sufficateLayerMask))
            {
                c_health.DoDamage(c_health.MaxHealth, hitPosition: point.point);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPatrol : MonoBehaviour
{
    
    public LayerMask mask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 10, mask, QueryTriggerInteraction.Ignore))
        {
            print(hitInfo.collider.gameObject);
            Destroy(hitInfo.transform.gameObject);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10, Color.green);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float debugDraw = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, debugDraw);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoRender : MonoBehaviour {

    public float radius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

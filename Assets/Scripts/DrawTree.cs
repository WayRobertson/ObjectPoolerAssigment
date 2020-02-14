using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTree : MonoBehaviour
{
    LineRenderer lineRenderer;
    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Vector3[] positions;
        if (transform.parent != null)
        {//connect self to parents position.
            positions = new Vector3[] { transform.parent.position, transform.position };
            lineRenderer.SetPositions(positions);
        }
        else
        {//no parent. this is the trunk.
            // lineRenderer.enabled = false;
        }
    }

}

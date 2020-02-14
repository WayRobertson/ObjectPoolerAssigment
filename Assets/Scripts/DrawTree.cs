using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class DrawTree : MonoBehaviour
{
    //Script Discription:This script uses the line renderer to draw the lines for the trees.
    LineRenderer lineRenderer;// reference to the linerenderer
    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Vector3[] positions;//Note: An array of the positions of the parent function
        if (transform.parent != null)//if the transform position of the parent is valid, it will draw a line from those points.
        {//connect self to parents position.
            positions = new Vector3[] { transform.parent.position, transform.position };
            lineRenderer.SetPositions(positions);
        }
        else
        {
            //Note: No lines will be drawn
        }
    }

}

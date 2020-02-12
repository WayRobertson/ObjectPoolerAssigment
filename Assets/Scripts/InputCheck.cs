using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour
{
    public GameObject treePrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 whereWeClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            whereWeClick = new Vector3(whereWeClick.x, whereWeClick.y, 0);
            Instantiate(treePrefab, whereWeClick, Quaternion.identity);
        }
    }
}

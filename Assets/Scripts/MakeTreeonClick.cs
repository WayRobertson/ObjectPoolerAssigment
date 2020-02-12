using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTreeonClick : MonoBehaviour
{
    public GameObject treePrefab;
    public List<GameObject> trees = new List<GameObject>();
   
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 whereWeClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            whereWeClick = new Vector3(whereWeClick.x, whereWeClick.y, 0);
            treePrefab = Instantiate(treePrefab, whereWeClick, Quaternion.identity);
            trees.Add(treePrefab);
        }
    }
}

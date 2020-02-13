using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTreeonClick : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject listcomponent;
    public int initialTreepool;
    public List<GameObject> treePool = new List<GameObject>();

    void Start()
    {
        treePool = new List<GameObject>();
        for (int i = 0; i < initialTreepool; i++)
        {
            if (!treePool[i].activeInHierarchy)
            {
                GameObject feebee = GameObject.Instantiate(listcomponent);
                feebee.SetActive(false);
                treePool.Add(feebee);
                //feebee is a GameObject temp name. Remember to change!
            }
        }
    }
#region MouseInput
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 whereWeClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            whereWeClick = new Vector3(whereWeClick.x, whereWeClick.y, 0);
            listcomponent = Instantiate(treePrefab, whereWeClick, Quaternion.identity);
        }
    }
  #endregion  
    // public GameObject AddTree()
    // {
    //     for (int i = 0; i < treePool.Count; i++)
    //     {
    //         if (!treePool[i].activeInHierarchy)
    //         {
    //             return treePool[i];
    //         }
    //     }
    // }
}

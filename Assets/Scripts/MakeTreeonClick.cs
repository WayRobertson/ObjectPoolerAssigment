using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTreeonClick : MonoBehaviour
{
    public GameObject treePrefab;
    public int initialTreepool;
    List<GameObject> treePool = new List<GameObject>();

    void Start()
    {
        treePool = new List<GameObject>();
        for (int i = 0; i < initialTreepool; i++)
        {
                GameObject feebee = GameObject.Instantiate(treePrefab);
                feebee.SetActive(false);
                treePool.Add(feebee);
                //feebee is a GameObject temp name. Remember to change!
            
        }
    }
#region MouseInput
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 whereWeClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            whereWeClick = new Vector3(whereWeClick.x, whereWeClick.y, 0);
            AddTree(whereWeClick);
        }
    }
  #endregion  
    public GameObject AddTree(Vector3 pos)
    {
        for (int i = 0; i < treePool.Count; i++)
        {
            if (!treePool[i].activeInHierarchy)
            {
                treePool[i].transform.position = pos;
                treePool[i].SetActive(true);
                return treePool[i];
            }
        }
        /////
         GameObject temp = Instantiate(treePrefab, pos, Quaternion.identity);
        treePool.Add(temp);
        return null;
    }
}

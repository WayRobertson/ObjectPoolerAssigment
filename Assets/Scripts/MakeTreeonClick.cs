using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script Discription: this script handles the input and ObjectPooler.
#region RequiredComponents
[RequireComponent(typeof(TreeGenerator))]
[RequireComponent(typeof(DrawTree))]
#endregion
public class MakeTreeonClick : MonoBehaviour
{
    public GameObject treePrefab;
    [Tooltip("Edits the number of trees in the object pooler (or 'treePool')")]
    public int initialTreepool;//size of the object pooler
    List<GameObject> treePool = new List<GameObject>();

    void Start()
    {
        //Note:If the number of trees in the pool are lesser than the pool size... 
        //Continued:...the list of trees will be enactive and it will add a tree to the pooler.
        treePool = new List<GameObject>();
        for (int i = 0; i < initialTreepool; i++)
        {
            GameObject tree = GameObject.Instantiate(treePrefab);// This will make a copy of the tree prefab.
            tree.SetActive(false);// this deactivates all of the tree game objects in the pooler.
            treePool.Add(tree);//adds the tree prefabs to the pooler.
        }
    }
    #region MouseInput
    void Update()
    {
        // Generates a tree where ever the mouse is pressed in the scene.
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
        //Note:Activates the trees in the Object pooler when called in the update script
        for (int i = 0; i < treePool.Count; i++)
        {
            if (!treePool[i].activeInHierarchy)
            {
                treePool[i].transform.position = pos;
                treePool[i].SetActive(true);
                return treePool[i];
            }
        }
        //Note: Adds another tree to the object pooler if it exceeds its original limit. 
        GameObject treeElement = Instantiate(treePrefab, pos, Quaternion.identity);
        treePool.Add(treeElement);
        return null;
    }

    void ErrorChecks()
    {
        if (treePrefab == null)
        {
            Debug.LogError("Attach TreePrefab");
        }
    }
}

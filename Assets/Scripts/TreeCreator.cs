using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generates a tree, but just from this one script.
public class TreeCreator : MonoBehaviour
{
    public GameObject branchPrefab;
    void Start()
    {
        //GameObject.FindGameObjectsWithTag("tag");//return an array of gameObjects that all have some tag.

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CreateBranch();
    }


    //update
    //if(Input.GetMouseButtonDown(0)){
        //Every click
        //INstantiate.... 
        
   // }
    void CreateBranch()
    {
        Vector3 branchPosition = transform.position;
        for(int i=0;i<10;i++){
            Vector3 offset = Random.onUnitSphere;
            offset = new Vector3(offset.x, Mathf.Abs(offset.y),0);
            branchPosition = branchPosition+offset;

            GameObject.Instantiate(branchPrefab,branchPosition,Quaternion.identity,transform);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for generating trees with the line renderer.
// "yeild retun new WaitForSeconds"(?). ANS: After some seconds pass inbetween the last line of code and this one... create this branch
public class TreeGenerator : MonoBehaviour
{
    public GameObject treelimb;
    public GameObject treeprefab;

    void Start()
    {
        StartCoroutine(CreateTree());
    }
    IEnumerator CreateTree()
    {
        // yield return new WaitForSeconds(0.2f);
        //creates three initial branches if the gameobject does not have a parent. The first three can be consider the trunk.
        if (transform.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        // creates a new branch from the previous branches if its parent does not have a parent.
        else if (transform.parent.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent.parent == null)
        //and the cycle continues.
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        //if this branch does not have a great grand parent then create another branch, otherwise no more branches.
        else if (transform.parent.parent.parent.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
    }



    public void MakeBranch()
    {
      Instantiate(treelimb, transform.position + Random.onUnitSphere + new Vector3(0, 1, 0), Quaternion.identity, transform);
    }


    // public void MakeBranch(int counter){
    //     if(counter < 5){
    //         counter++;
    //         GameObject child = Instantiate(treelimb,transform.position + Random.onUnitSphere + new Vector3 (0,1,0), Quaternion.identity,transform);
    //         child.GetComponent<TreeGenerator>().MakeBranch(counter);
    //         //float Angle = Vector3.Angle(1f,90f);
    //     }
    // }
}
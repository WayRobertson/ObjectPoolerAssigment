using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Discription: This script is for generating trees with the line renderer.
// "yeild retun new WaitForSeconds"(?). ANS: After some seconds pass (inbetween the last line of code and this one) create this branch
public class TreeGenerator : MonoBehaviour
{

    public GameObject treelimb;// Game Object for instantating the branches
    public GameObject treeprefab;

    void Start()
    {
        StartCoroutine(CreateTree());// every child branch will be delayed by a fraction of a second
        StartCoroutine(WaitThenDisable(5));// every tree that is created will be disabled after 5 seconds
    }
    IEnumerator WaitThenDisable(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        gameObject.SetActive(false);
    }
    IEnumerator CreateTree()
    {
        //Note: creates three initial branches if the gameobject does not have a parent. The first three can be consider the trunk of the tree.
        if (transform.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        // Note: Creates a new branch from the previous branches if its parent does not have a parent.
        // Continued: This statment will create two new branches on the previous ones. 
        else if (transform.parent.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent.parent == null)
        //Note: and the cycle continues, but this time it will only create one new branch from its parent.
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        //if this branch does not have a 'great' grand parent then create another branch, otherwise no more branches.
        else if (transform.parent.parent.parent.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
    }



    public void MakeBranch()
    {
      // creates an individual branch that gets multiplied and divides as discribed above 
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
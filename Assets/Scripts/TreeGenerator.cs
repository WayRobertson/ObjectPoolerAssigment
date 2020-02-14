using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script Discription:This script is for generating trees with the line renderer.
#region RequiredComponents
[RequireComponent(typeof(MakeTreeonClick))]
[RequireComponent(typeof(DrawTree))]
[RequireComponent(typeof(GameObject))]
#endregion
public class TreeGenerator : MonoBehaviour
{
    public GameObject treelimb;// Note: Game Object for instantating the branches.
    void Start()
    {
        StartCoroutine(CreateTree());// Note: Every child branch will be delayed by a fraction of a second.
        StartCoroutine(WaitThenDisable(5));// Note: Every tree that is created will be disabled after 5 seconds.
    }
    IEnumerator WaitThenDisable(float timeToWait)//Note: Deactivates the trees after a certain period of time.
    {
        yield return new WaitForSeconds(timeToWait);
        gameObject.SetActive(false);
    }
    IEnumerator CreateTree()
    {
        //Note on delayed generation of branches: After some time passes (inbetween the last line of code and this one) it will create a new branch.
        //Note(1): Creates three initial branches if the gameobject does not have a parent. The first three can be considered the trunk of the tree.
        if (transform.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent == null)
        // Note(2): Creates a new branch from the previous branches if its parent does not have a parent...
        // Continued: This statment will create two new branches on the previous ones.
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent.parent == null)
        //Note(3): and the cycle continues, but this time it will only create one new branch from its parent.
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent.parent.parent == null)
        //Note(4): If this branch does not have a 'great' grand parent then create another branch, otherwise no more branches.
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
    }

    public void MakeBranch()
    {
        //Creates an individual branch which creates children branches that break off from it and then those children branches break off from themsleves (and so on) untill it looks like a tree. 
        Instantiate(treelimb, transform.position + Random.onUnitSphere + new Vector3(0, 1, 0), Quaternion.identity, transform);
    }

    #region Unused Code

    // public void MakeBranch(int counter){
    //     if(counter < 5){
    //         counter++;
    //         GameObject child = Instantiate(treelimb,transform.position + Random.onUnitSphere + new Vector3 (0,1,0), Quaternion.identity,transform);
    //         child.GetComponent<TreeGenerator>().MakeBranch(counter);
    //         //float Angle = Vector3.Angle(1f,90f);
    //     }
    // }
    #endregion
}
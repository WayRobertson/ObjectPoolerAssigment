using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treelimb;

    void Start()
    {
        StartCoroutine(CreateTree());
    }
    IEnumerator CreateTree()
    {
        // yield return new WaitForSeconds(0.2f);
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
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
        else if (transform.parent.parent.parent == null)
        {
            yield return new WaitForSeconds(0.1f);

            MakeBranch();
        }
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
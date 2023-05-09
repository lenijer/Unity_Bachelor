using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public CombinationData Data;
    public GameObject button;
    public GameObject spawnLoc;

    private GameObject colliding_obj;

    public void Combine_func()
    {
        bool cancombine = Data.CheckIfPosible(colliding_obj.GetComponent<Molecule>());
        if (cancombine)
        {
            GameObject obj = Instantiate(Data.Combinee);
            obj.transform.position = spawnLoc.transform.position;
            //Debug.Log("Combination Succsess");
        }
        /*else
        {
            Debug.Log("No combination possible");
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        //GameObject collider;
        colliding_obj = collision.gameObject;
        if (colliding_obj.tag == "Molecule")
        {
            button.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            button.SetActive(false);
        }
    }
}

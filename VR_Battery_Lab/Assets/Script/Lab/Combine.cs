using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public CombinationData Data;    //refrence to combination data
    public GameObject button;       //it a refrence to an object that is to be hidden or unhidden
    public GameObject spawnLoc;     //has it's own little spawn location

    private GameObject colliding_obj;   //a refrence to the object colliding whith this one

    //will spawn the "result" of a succsessfull combination
    public void Combine_func()
    {
        bool cancombine = Data.CheckIfPosible(colliding_obj.GetComponent<Molecule>());
        if (cancombine)
        {
            GameObject obj = Instantiate(Data.Combinee);
            obj.transform.position = spawnLoc.transform.position;
        }
    }

    //checks for a molecule collision
    void OnCollisionEnter(Collision collision)
    {
        colliding_obj = collision.gameObject;
        if (colliding_obj.tag == "Molecule")
        {
            button.SetActive(true);
        }
    }

    //checks if the molecule stops colliding
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

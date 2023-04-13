using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Load : MonoBehaviour
{
    public GameObject o;

    private GameObject collider;

    void OnCollisionEnter(Collision collision)
    {
        //GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            o.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            o.SetActive(false);
        }
    }

    public void save()
    {
        SaveLoad.SaveData(collider.GetComponent<Molecule>());
    }
}

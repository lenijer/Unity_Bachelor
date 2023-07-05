using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void OnCollisionStay(Collision collision)  //is a funktion set to destroy a object thet is either a Molcule, Atom or Item
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            Destroy(collider);
        } else if (collider.tag == "Atom")
        {
            Destroy(collider);
        }
        else if (collider.tag == "Item")
        {
            Destroy(collider);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

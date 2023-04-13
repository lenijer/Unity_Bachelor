using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void OnCollisionStay(Collision collision)
    {
        //Debug.Log("c");
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            Destroy(collider);
            //Debug.Log("a");
        } else if (collider.tag == "Atom")
        {
            Destroy(collider);
            //Debug.Log("p");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AtomBehaviour : MonoBehaviour
{
    public Atom atomic;
    public GameObject parent_pref;

    private GameObject parent;
    private bool hasparent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Atom")
        {
            Treat_collision(collider);
        }
    }

    private void Treat_collision(GameObject col)
    {
        //Debug.Log("still good");
        if (hasparent)
        {
            //Debug.Log("it it here");
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                if (getParent().name != col.GetComponent<AtomBehaviour>().getParent().name)
                {

                }

            }else {
                this.parent.GetComponent<Molecule>().AddChild(col);
            }
        }
        else
        {
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                //Debug.Log("it it here");
                col.GetComponent<AtomBehaviour>().getParent().GetComponent<Molecule>().AddChild(this.gameObject);
            }
            else
            {
                //Debug.Log("or here");
                Vector3 changes;
                changes = this.gameObject.transform.position;

                GameObject parent_obj = Instantiate(parent_pref);
                parent_obj.name = atomic.identifier + col.GetComponent<AtomBehaviour>().atomic.identifier;
                //Debug.Log("j");

                this.gameObject.transform.position = Vector3.one * (0.1f);
                parent_obj.GetComponent<Molecule>().AddChild(this.gameObject);
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //Debug.Log(this.name);
                //Debug.Log("a");
                col.transform.position = Vector3.one * (-0.1f);
                parent_obj.GetComponent<Molecule>().AddChild(col);
                col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //Debug.Log(col.name);
                //Debug.Log("b");

                parent_obj.transform.position = changes;
                //Debug.Log("c");
            }
        }
    }

    public bool haveparent()
    {
        return hasparent;
    }

    public void setParent(GameObject p)
    {
        parent = p;
        hasparent = true;
        //this.gameObject.transform.SetParent(p.transform);
        //Debug.Log(this.name);
        GetComponent<XRGrabInteractable>().enabled = false;
    }

    public GameObject getParent()
    {
        return parent;
    }
}

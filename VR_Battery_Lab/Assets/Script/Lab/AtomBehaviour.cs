using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AtomBehaviour : MonoBehaviour
{
    public Atom atomic;                             //Atom class to hold information from the button
    public GameObject labelPrefab;
    public GameObject electronPrefab;
    public float orbitDistance = 0.1f;
    private Vector3 rotationVector = Vector3.up;

    public ParticleSystem ps;

    public GameObject parent_pref;                  //refrence to the molecule prefab

    private GameObject parent;                      //is to tell which molecule is the parent
    private bool hasparent = false;                 //tells if the object has a parent

    // Start is called before the first frame update
    void Start()
    {
        ShowLabel(); 
        GenerateElectrons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when an object collides it checks if it is an atom, and if it is it runs the collision treater
    void OnCollisionEnter(Collision collision) 
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Atom")
        {
            Treat_collision(collider);
        }
    }

    //treats a collision with another atom and potentially creates a molecule
    private void Treat_collision(GameObject col) 
    {
        if (hasparent)
        {
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                if (getParent().name != col.GetComponent<AtomBehaviour>().getParent().name)
                {
                    //this would essentially be two molecules colliding
                }

            }else {
                this.parent.GetComponent<Molecule>().AddChild(col); //tells the molecule it now has another child
            }
        }
        else
        {
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                col.GetComponent<AtomBehaviour>().getParent().GetComponent<Molecule>().AddChild(this.gameObject); //adds this game object as the child of a molecule
            }
            else //this triggers when neither atom has a molecule parent. It the creates a molecule
            {
                Vector3 changes;
                changes = this.gameObject.transform.position;

                GameObject parent_obj = Instantiate(parent_pref);   //creates the molecule from a prefab
                parent_obj.name = atomic.identifier + col.GetComponent<AtomBehaviour>().atomic.identifier; //the name of the molecule becoms the combination of the two atoms' names ex. Na + Cl gives the name NaCl
                parent_obj.transform.position = changes + new Vector3(0,-0.1f,0);   //offsets the position of the object a bit

                parent_obj.GetComponent<Molecule>().AddChild(this.gameObject);  //tells the molecule it now has a child
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; //freezes the local posiiton of the object owning the script

                parent_obj.GetComponent<Molecule>().AddChild(col);  //tells the molecule it now has another child
                col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;    //freezes the local position of the object that colided with this
            }
        }
    }

    public bool haveparent()
    {
        return hasparent;
    }

    public void setParent(GameObject p)
    {
        ps.Play();
        parent = p;
        hasparent = true;
        GetComponent<XRGrabInteractable>().enabled = false; //Skrur av Evnen til å grabbe atomet når det er del av Molekylet
    }

    public GameObject getParent()
    {
        return parent;
    }

    void ShowLabel()    //  Function for making and placing the lable appropriatly
    {   
        //  Declare a lable variable
        var lab = Instantiate(labelPrefab, transform.position, Quaternion.identity, transform);

        //  Set different text values. Identifier, name, number and atomic mass. This is to replicate the look from the periodic table
        lab.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.identifier;
        lab.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.value.ToString();
        lab.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.atom_name;
        lab.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.mass.ToString();
        //  Makes the label a child of the atom object
        lab.gameObject.transform.SetParent(this.gameObject.transform);
    }

    void GenerateElectrons()    //  Function for generating a simplified visual repersantation of the electron shells
    {
        int count = atomic.value;   //  First we get the atomic value to represent the amount of electrons

        float tempdistance = orbitDistance; //  Sets the distance from the core atom
        if (count > 2)                      //  We check if we have more electrons than the shell can hold
        {   
            addElectron(2);                 //  If we do, we fill the shell...
            count -= 2;                     //  ...and then remove them from the total we have
        }                    
        else                                //  Else we add all we have to the shell
        {   addElectron(count);             
            return; }

        rotationVector = Vector3.right;         //  Change the electron rotation vector to use the vr space more
        orbitDistance = tempdistance * 1.2f;    //  Increases the distance from the core atom
        if (count > 8)                          //  We check if we have more electrons than the shell can hold
        {   
            addElectron(8);                 //  If we do, we fill the shell...
            count -= 8;                     //  ...and then remove them from the total we have
        }
        else                                //  Else we add all we have to the shell
        {   addElectron(count);
            return; }

        rotationVector = new Vector3(1f,1f,0f); //  Change the electron rotation vector to use the vr space more
        orbitDistance = tempdistance * 1.4f;    //  Increases the distance from the core atom
        if (count > 18)                         //  We check if we have more electrons than the shell can hold
        {   
            addElectron(18);                //  If we do, we fill the shell...
            count -= 18;                    //  ...and then remove them from the total we have
        }
        else                                //  Else we add all we have to the shell
        {   addElectron(count);
            return; }

        rotationVector = new Vector3(1f, -1f, 0f);  //  Change the electron rotation vector to use the vr space more
        orbitDistance = tempdistance * 1.6f;        //  Increases the distance from the core atom
        if (count > 32)                         //  We check if we have more electrons than the shell can hold
        {   
            addElectron(32);                //  If we do, we fill the shell...
            count -= 32;                    //  ...and then remove them from the total we have
        }
        else                                //  Else we add all we have to the shell
        {   addElectron(count);
            return; }

        rotationVector = Vector3.left;          //  Change the electron rotation vector to use the vr space more
        orbitDistance = tempdistance * 1.8f;    //  Increases the distance from the core atom
        if (count > 50)                         //  We check if we have more electrons than the shell can hold
        {   
            addElectron(50);                //  If we do, we fill the shell...
            count -= 50;                    //  ...and then remove them from the total we have
        }
        else                                //  Else we add all we have to the shell
        {   addElectron(count);
            return; }

        rotationVector = Vector3.down;          //  Change the electron rotation vector to use the vr space more
        orbitDistance = tempdistance * 2f;      //  Increases the distance from the core atom
        addElectron(count);                     //  Add what electrons we have left for the final shell

    }

    void addElectron (int index)    //  A function for creating the electron shells themselves and fill them
    {
        //  Firt we split the area around the atom in equal parts to get an equal distance between electrons
        float angleStep = 360.0f / index;
        //  Then we loop through the amount we were given
        for (int i = 0; i < index; i++)
        {
            //  First we create the electron game object
            GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
            //  Then we give it its orbit distance
            el.GetComponent<ElectronOrbit>().orbitDistance = orbitDistance;
            //  Next we make the atom its parent
            el.gameObject.transform.SetParent(this.gameObject.transform);
            //  Before we rotate it an amount equal to its divided portion to space them out
            el.transform.RotateAround(this.transform.position, rotationVector, angleStep * i);
            //  And finaly we let the electron know how it is supposed to rotate
            el.GetComponent<ElectronOrbit>().orbitRotation = rotationVector;
        }
    }
}

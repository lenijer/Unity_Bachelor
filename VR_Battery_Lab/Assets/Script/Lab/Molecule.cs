using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour
{
    public List<GameObject> AtomChildren; //holds a refrence to the children of this parent object.

    public string molecule_name;    //sets the name for the spawned molecule
    public List<int> atoms;         //is a list of the "value" for the atoms in the molecule

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.name = molecule_name; //makes sure the name is correct
    }

    public void AddChild(GameObject atom)
    {
        AtomChildren.Add(atom);                                                 //adds the incoming game object to the list of children
        atoms.Add(atom.GetComponent<AtomBehaviour>().atomic.value);             //adds the value of the atom to the list of children
        molecule_name += atom.GetComponent<AtomBehaviour>().atomic.identifier;  //adds to the full name of the molecule, when a new atom has entered
        atom.GetComponent<AtomBehaviour>().setParent(this.gameObject);          //sets this as the parent of the atom
        atom.gameObject.transform.SetParent(this.gameObject.transform);         //tells the atom it has gotten a parent
    }
}

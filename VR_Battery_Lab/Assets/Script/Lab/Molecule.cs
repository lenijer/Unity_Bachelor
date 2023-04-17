using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour
{
    public List<GameObject> AtomChildren;

    public string molecule_name;
    public List<int> atoms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.name = molecule_name;
    }

    public void AddChild(GameObject atom)
    {
        AtomChildren.Add(atom);
        atoms.Add(atom.GetComponent<AtomBehaviour>().atomic.value);
        molecule_name += atom.GetComponent<AtomBehaviour>().atomic.identifier;
        atom.GetComponent<AtomBehaviour>().setParent(this.gameObject);
        atom.gameObject.transform.SetParent(this.gameObject.transform);
    }
}

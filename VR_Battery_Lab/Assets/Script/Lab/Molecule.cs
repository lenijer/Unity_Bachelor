using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecule : MonoBehaviour
{
    public List<GameObject> AtomChildren;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChild(GameObject atom)
    {
        AtomChildren.Add(atom);
        atom.GetComponent<AtomBehaviour>().setParent(this.gameObject);
        atom.gameObject.transform.SetParent(this.gameObject.transform);
    }
}

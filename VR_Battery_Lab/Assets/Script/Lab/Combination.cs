using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public List<int> atom_number;       //is a list holding the atom/elements number in the periodic table
    public string Name;                 //is the commonly used name for the product
    public string Chemical_name;        //is the chemical name or the name consisting of the combined atoms ex. NaCl for salt
    public bool Discovered = false;     //just holds the information on weather or not the specific item has been discovered

    public void Discover()
    {
        Discovered = true;
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

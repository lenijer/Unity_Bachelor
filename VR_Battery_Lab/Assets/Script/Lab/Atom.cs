using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public int value;         //is the periodictable number ex. Iron = 26

    public float mass;        //is the atomic mass of the element

    public string identifier; //is the string that the element uses in the periodictable ex. Fe for Iron
    public string atom_name;  //is the name of the element

    public void input_info(Atom atom) //used for tranfering the data
    {
        value = atom.value;
        mass = atom.mass;
        identifier = atom.identifier;
        atom_name = atom.atom_name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public int value;

    public float mass;

    public string identifier;
    public string atom_name;

    public void input_info(Atom atom)
    {
        value = atom.value;
        mass = atom.mass;
        identifier = atom.identifier;
        atom_name = atom.atom_name;
    }
    /*void Start()
    {
        atom_name = this.name;
    }*/
}

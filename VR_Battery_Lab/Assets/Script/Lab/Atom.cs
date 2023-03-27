using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public int value;

    public float mass;

    public string identifier;
    public string atom_name;

    void Start()
    {
        atom_name = this.name;
    }
}

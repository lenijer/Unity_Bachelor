using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes the data saved as simplefied as possible
[System.Serializable]
public class MoleculeData
{
    public string Name;
    public int[] Atoms;

    public MoleculeData(Molecule molecule)
    {
        Name = molecule.molecule_name;
        Atoms = molecule.atoms.ToArray();
    }
}

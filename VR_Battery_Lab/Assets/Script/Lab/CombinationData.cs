using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationData : MonoBehaviour
{
    public AtomData Refrence;
    public List<GameObject> Objects;
    public GameObject Combinee;
    public Progress prog;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CheckIfPosible(Molecule molecule)
    {
        int thing = 0;
        for (int i = 0; i < Objects.Count; i++)
        {
            //Debug.Log(Objects[i].GetComponent<Combination>().Name);
            if (Objects[i].GetComponent<Combination>().atom_number.Count == molecule.atoms.Count)
            {
                thing = 0;
                //Debug.Log(Objects[i].GetComponent<Combination>().atom_number + " & " + molecule.atoms);
                for (int a = 0; a < molecule.atoms.Count; a++)
                {
                    for (int b = 0; b < Objects[i].GetComponent<Combination>().atom_number.Count; b++)
                    {
                        //Debug.Log(Objects[i].GetComponent<Combination>().atom_number[b] + " & " + molecule.atoms[a]);
                        if (molecule.atoms[a] == Objects[i].GetComponent<Combination>().atom_number[b] && a == b)
                        {
                            thing++;
                            if (thing == molecule.atoms.Count)
                            {
                                Objects[i].GetComponent<Combination>().Discover();
                                Combinee = Objects[i];
                                prog.DiscoveredAnItem(Objects[i]);
                                return true;
                            }
                        }
                        //exend here for unidentical molecules
                    }
                }
            }
        }
        return false;
    }

    public Atom MatchData(int atomnumber)
    {
        Atom returnee = new Atom();

        for (int i = 0; i < Refrence.atoms.Count; i++)
        {
            if (Refrence.atoms[i].value == atomnumber)
            {
                returnee = Refrence.atoms[i];
                break;
            }
        }

        return returnee;
    }
}

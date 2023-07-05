using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationData : MonoBehaviour
{
    public AtomData Refrence;           //is a refrence to all the atoms
    public List<GameObject> Objects;    //is a list of premade objects which will hold information on possible combinations of atoms
    public GameObject Combinee;         //just holds a refrence to the object thats going to be checked
    public Progress prog;               //is to help show the user their progress

    // Start is called before the first frame update
    void Start()
    {

    }

    //goes through all available atoms and checks which ones are posiisble. As of right now only a perfect mach is viable.
    public bool CheckIfPosible(Molecule molecule)
    {
        int thing = 0;
        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i].GetComponent<Combination>().atom_number.Count == molecule.atoms.Count)
            {
                thing = 0;
                for (int a = 0; a < molecule.atoms.Count; a++)
                {
                    for (int b = 0; b < Objects[i].GetComponent<Combination>().atom_number.Count; b++)
                    {
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

    //sends back what atom it it based on it's integer/value
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    public CombinationData PossibleCombos;  //refrence to the combination data
    public GameObject MenuPrefab;           //refrence to a prefab menu item
    public GameObject Menu;                 //direct refrence to a menu


    private List<GameObject> ObjectsToBeEnabaled;

    void Start()
    {
        //sets up a showing for the purpose of guiding players to what they should combine
        for (int i = 0; i < PossibleCombos.Objects.Count; i++)
        {
            GameObject spawn = Instantiate(MenuPrefab);
            spawn.transform.parent = Menu.transform.GetChild(0).GetChild(0).GetChild(0);
            spawn.transform.localScale = MenuPrefab.transform.localScale;
            spawn.transform.localRotation = MenuPrefab.transform.localRotation;
            spawn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            string Combos = "";
            for (int j = 0; j < PossibleCombos.Objects[i].GetComponent<Combination>().atom_number.Count; j++)
            {
                Atom cool = PossibleCombos.MatchData(PossibleCombos.Objects[i].GetComponent<Combination>().atom_number[j]);
                if (j == PossibleCombos.Objects[i].GetComponent<Combination>().atom_number.Count - 1)
                {
                    Combos += cool.identifier.ToString() + " = ";
                }
                else
                {
                    Combos += cool.identifier.ToString() + " + ";
                }
            }
            spawn.transform.GetChild(0).GetComponent<TMP_Text>().text = Combos;
            spawn.transform.GetChild(1).name = PossibleCombos.Objects[i].GetComponent<Combination>().Name + "_lbl";
        }
    }

    //adds the result to the menu when an item has been discovered
    public void DiscoveredAnItem(GameObject discovered)
    {
        if (discovered.GetComponent<Combination>().Discovered)
        {
            GameObject ItemToChange = GameObject.Find(discovered.GetComponent<Combination>().Name + "_lbl");
            ItemToChange.GetComponent<TMP_Text>().text = discovered.GetComponent<Combination>().Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

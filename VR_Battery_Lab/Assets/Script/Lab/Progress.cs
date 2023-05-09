using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    public CombinationData PossibleCombos;
    public GameObject MenuPrefab;
    public GameObject Menu;


    private List<GameObject> ObjectsToBeEnabaled;

    void Start()
    {
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
            //spawn.transform.GetChild(1).GetComponent<TMP_Text>().text = PossibleCombos.Objects[i].GetComponent<Combination>().Name;
            spawn.transform.GetChild(1).name = PossibleCombos.Objects[i].GetComponent<Combination>().Name + "_lbl";
        }
    }

    public void DiscoveredAnItem(GameObject discovered)
    {
        if (discovered.GetComponent<Combination>().Discovered)
        {
            GameObject ItemToChange = GameObject.Find(discovered.GetComponent<Combination>().Name + "_lbl");
            //if (!ItemToChange.activeSelf)
            //{
            ItemToChange.GetComponent<TMP_Text>().text = discovered.GetComponent<Combination>().Name;
            //5}
            /*for (int i = 0; i < ObjectsToBeEnabaled.Count; i++)
            {
                if (discovered.GetComponent<Combination>().Name == ObjectsToBeEnabaled[i].name)
                {
                    if (!ObjectsToBeEnabaled[i].activeSelf)
                    {
                        ObjectsToBeEnabaled[i].SetActive(true);
                    }
                }
            }*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

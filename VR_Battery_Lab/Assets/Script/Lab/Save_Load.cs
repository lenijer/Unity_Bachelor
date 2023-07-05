using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Save_Load : MonoBehaviour
{
    public GameObject o;                            //Is a refrence to the menu that shows the save button
    public GameObject a;                            //holds a refrence to the menu where molecules get their spawn inn button from
    public GameObject spawn;                        //holds the location for spawning inn atoms and molecules
    public GameObject DataHandler;                  //Holds a refrence to the data manager in the scene

    public GameObject ButtonPrefab;                 //is a prefab for a button

    public List<string> SaveNames;                  //is a list of all the names of the saved objects

    private GameObject collider;                    //is for holding the information on what geme object collided with the parent object

    //when a cmolecule object enter this funktion will save it to the collider game object and show the menu for saving it
    void OnCollisionEnter(Collision collision)
    {
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            o.SetActive(true);
        }
    }

    //This funktion will hide the save menu when the molecule object exits the parent collider
    void OnCollisionExit(Collision collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            o.SetActive(false);
        }
    }

    public void save()
    {
        SaveLoad.SaveData(collider.GetComponent<Molecule>()); //tells the data that is supposed to be saved
        SaveNames.Add(collider.name);                         //adds the saved molecule to the list of names of saved molecules
        SaveLoad.SaveNames(SaveNames);                        //saves the list of molecule names
    }

    //should refresh the molecule menu
    public void reloadmenu()
    {
        if (a.activeSelf)
        {
            showloadmenu();
        }
    }

    public void showloadmenu()
    {
        a.SetActive(true);                                      //shows menu a
        SaveNames = new List<string>(SaveLoad.LoadNames());     //fetches the list of all the saved molecules
        for (int i = 0; i < SaveNames.Count; i++)               //creates and loads inn all the nessesary buttons
        {
            if (GameObject.Find(SaveNames[i] + "_btn") == false)
            {
                GameObject spawnedbutton = Instantiate(ButtonPrefab);                                               //creates a button based on the prefab
                spawnedbutton.transform.parent = a.transform.GetChild(0).GetChild(0).GetChild(0);                   //places the button under the correct parent
                spawnedbutton.transform.localScale = ButtonPrefab.transform.localScale;                             //resets the scale of the butten after it had been parented
                spawnedbutton.transform.localRotation = ButtonPrefab.transform.localRotation;                       //resets the rotation after parenting
                spawnedbutton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);                   //resets the position after parenting, needed in cobbination with the scroll view used
                spawnedbutton.GetComponent<MoleculeSpawn>().spawner = spawn;                                        //tells the button which spawn to use
                spawnedbutton.GetComponent<MoleculeSpawn>().AtomData = DataHandler.GetComponent<AtomData>().atoms;  //gives the nessesary spawning information to the button
                spawnedbutton.name = SaveNames[i] + "_btn";                                                         //gives the button it's name
                GameObject.Find(SaveNames[i] + "_btn").GetComponentInChildren<TMP_Text>().text = SaveNames[i];      //sets the text displaying in the button
            }
        }
    }

    //fetches the data of a molecule and creates it
    public Molecule load(string name)
    {
        MoleculeData m = SaveLoad.LoadData(name);   //loads the nessesary molecule data
        Molecule mol = new Molecule();              //creates a empty molecule

        mol.molecule_name = m.Name;                 //gives the molecule a name
        mol.atoms = new List<int>(m.Atoms);         //tells the molecule which atoms it contains

        return mol;
    }
}

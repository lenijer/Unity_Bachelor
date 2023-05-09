using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Save_Load : MonoBehaviour
{
    public GameObject o;
    public GameObject a;
    public GameObject spawn;
    public GameObject DataHandler;

    public GameObject ButtonPrefab;

    public List<string> SaveNames;

    private GameObject collider;

    void OnCollisionEnter(Collision collision)
    {
        //GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Molecule")
        {
            o.SetActive(true);
        }
    }

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
        SaveLoad.SaveData(collider.GetComponent<Molecule>());
        SaveNames.Add(collider.name);
        SaveLoad.SaveNames(SaveNames);
    }

    public void reloadmenu()
    {
        if (a.activeSelf)
        {
            showloadmenu();
        }
    }

    public void showloadmenu()
    {
        a.SetActive(true);
        //SaveNames.Clear();
        SaveNames = new List<string>(SaveLoad.LoadNames());
        for (int i = 0; i < SaveNames.Count; i++)
        {
            if (GameObject.Find(SaveNames[i] + "_btn") == false)
            {
                GameObject spawnedbutton = Instantiate(ButtonPrefab);
                spawnedbutton.transform.parent = a.transform.GetChild(0).GetChild(0).GetChild(0);
                spawnedbutton.transform.localScale = ButtonPrefab.transform.localScale;
                spawnedbutton.transform.localRotation = ButtonPrefab.transform.localRotation;
                spawnedbutton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                spawnedbutton.GetComponent<MoleculeSpawn>().spawner = spawn;
                spawnedbutton.GetComponent<MoleculeSpawn>().AtomData = DataHandler.GetComponent<AtomData>().atoms;
                spawnedbutton.name = SaveNames[i] + "_btn";
                GameObject.Find(SaveNames[i] + "_btn").GetComponentInChildren<TMP_Text>().text = SaveNames[i];
            }
        }
    }

    public Molecule load(string name)
    {
        MoleculeData m = SaveLoad.LoadData(name);
        Molecule mol = new Molecule();

        mol.molecule_name = m.Name;
        mol.atoms = new List<int>(m.Atoms);

        return mol;
    }
}

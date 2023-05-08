using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeSpawn : MonoBehaviour
{
    public GameObject MoleculePrefab;
    public GameObject spawner;
    public List<Atom> AtomData;
    public GameObject AtomPrefab;

    private GameObject Saver;

    // Start is called before the first frame update
    void Start()
    {
        Saver = GameObject.Find("Saver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMolecule()
    {
        string name = this.name;
        name = name.Replace("_btn", "");
        Molecule mol = Saver.GetComponent<Save_Load>().load(name);
        GameObject spawned = Instantiate(MoleculePrefab);
        spawned.GetComponent<Molecule>().molecule_name = mol.molecule_name;
        spawned.GetComponent<Molecule>().atoms = mol.atoms;

        float offset = 1f;
        for (int i = 0; i < mol.atoms.Count; i++)
        {
            for (int j = 0; j < AtomData.Count; j++)
            {
                if (mol.atoms[i] == AtomData[j].value)
                {
                    GameObject atm = Instantiate(AtomPrefab);

                    atm.GetComponent<AtomBehaviour>().atomic = AtomData[j];
                    atm.name = AtomData[j].atom_name;

                    RawImage img = AtomData[j].transform.GetComponent<RawImage>();
                    Material mat = new Material(Shader.Find("Standard"));
                    mat.mainTexture = img.texture;
                    atm.GetComponent<MeshRenderer>().material = mat;

                    //spawned.GetComponent<Molecule>().AddChild(atm);
                    spawned.GetComponent<Molecule>().AtomChildren.Add(atm);
                    atm.GetComponent<AtomBehaviour>().setParent(spawned);
                    atm.gameObject.transform.SetParent(spawned.transform);
                    atm.transform.localPosition = new Vector3(0f + offset, 0f, 0f);

                    offset += 1f;
                }
            }
        }

        spawned.transform.position = spawner.transform.position;
        spawner.GetComponent<SpawnerInfo>().IsOccupied = true;
    }
}

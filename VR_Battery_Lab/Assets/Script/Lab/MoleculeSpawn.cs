using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawn : MonoBehaviour
{
    public GameObject MoleculePrefab;

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
        spawned.transform.position = this.transform.position;
        Vector3 offset = new Vector3(0.3f * Mathf.Sin(this.transform.rotation.y), 0, 0.3f * Mathf.Cos(this.transform.rotation.y));
        spawned.transform.position += offset * (-1);
    }
}

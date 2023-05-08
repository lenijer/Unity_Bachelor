using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Element : MonoBehaviour
{
    public GameObject SpawnLoc;
    //public GameObject Player;
    //public GameObject Menu;
    public GameObject spawnElementDefault;
    public GameObject spawnElectronDefault;

    public void SpawnElemant()
    {
        /*GameObject spawnedObject = Instantiate(Element);
        spawnedObject.transform.position = SpawnLoc.position;
        spawnedObject.transform.position += Vector3.up * 1;*/

        //GameObject spawnNew = new GameObject();
        //spawnNew = spawnElementDefault;
        if (SpawnLoc.GetComponent<SpawnerInfo>().IsOccupied == false)
        {
            GameObject spawnedObject = Instantiate(spawnElementDefault);

            RawImage img = this.GetComponent<RawImage>();

            spawnedObject.name = this.name;


            //spawnElementDefault.material = new Material(img.Texture);
            Material mat = new Material(Shader.Find("Standard"));
            mat.mainTexture = img.texture;
            spawnedObject.GetComponent<MeshRenderer>().material = mat;

            Atom atm = this.GetComponent<Atom>();
            spawnedObject.GetComponent<AtomBehaviour>().atomic = atm;

            spawnedObject.transform.position = SpawnLoc.transform.position;

            SpawnLoc.GetComponent<SpawnerInfo>().IsOccupied = true;
        }
    }

    void Update()
    {/*
        Vector3 Middle = new Vector3 (0f,0f,0f);
        Middle.x = Player.transform.position.x - Menu.transform.position.x;
        Middle.y = Menu.transform.position.y;
        Middle.z = Player.transform.position.z - Menu.transform.position.z;
        Middle = Middle / 2;
        SpawnLoc.transform.position = Middle;*/
    }
}

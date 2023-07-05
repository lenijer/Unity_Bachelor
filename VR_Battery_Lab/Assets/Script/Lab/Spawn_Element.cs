using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Element : MonoBehaviour
{
    public GameObject SpawnLoc;                 //Saves the location the object is going to spwn in
    public GameObject spawnElementDefault;      //Holds a prefab for the elements basic applications
    public GameObject spawnElectronDefault;     //Holds a prefab for the electorns

    public void SpawnElemant()
    {
        if (SpawnLoc.GetComponent<SpawnerInfo>().IsOccupied == false)       //Checks if it can spawn an object in the spawn location
        {
            GameObject spawnedObject = Instantiate(spawnElementDefault);    //Both creates a new object in the scene and generatees teh pointer to this element for more changes in code

            RawImage img = this.GetComponent<RawImage>();                   //Creates a raw image compoenent and gets the image used by this object

            spawnedObject.name = this.name;                                 //Gets the name of this object to use on the new object


            Material mat = new Material(Shader.Find("Standard"));           //Creates a new material based of the preamade material named Standard
            mat.mainTexture = img.texture;                                  //uses the earlier image component so set the texture of the material
            spawnedObject.GetComponent<MeshRenderer>().material = mat;      //changes the objects material to the newly created material

            Atom atm = this.GetComponent<Atom>();                           //gets the information in the atom class of this object
            spawnedObject.GetComponent<AtomBehaviour>().atomic = atm;       //Tranfers the Atom information onto the object

            spawnedObject.transform.position = SpawnLoc.transform.position; //Sets the position of the new object into the spawner

            SpawnLoc.GetComponent<SpawnerInfo>().IsOccupied = true;         //Tells the spawner that it has an object inside it
        }
    }

    void Update()
    {

    }
}

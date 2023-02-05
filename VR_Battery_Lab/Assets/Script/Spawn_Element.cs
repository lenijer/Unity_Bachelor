using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Element : MonoBehaviour
{
    public Transform SpawnLoc;
    //public GameObject Element;
    public GameObject spawnElementDefault;
    public GameObject spawnElectronDefault;

    public void SpawnElemant()
    {
        /*GameObject spawnedObject = Instantiate(Element);
        spawnedObject.transform.position = SpawnLoc.position;
        spawnedObject.transform.position += Vector3.up * 1;*/

        GameObject spawnNew = spawnElementDefault;

        RawImage img = this.GetComponent<RawImage>();

        spawnNew.name = this.name;

        spawnNew.transform.position = SpawnLoc.position;
        spawnNew.transform.position += Vector3.up * 1;

        //spawnElementDefault.material = new Material(img.Texture);
        Material mat = new Material(Shader.Find("Standard"));
        mat.mainTexture =  img.texture;
        spawnNew.GetComponent<MeshRenderer>().material = mat;

        GameObject spawnedObject = Instantiate(spawnNew);
    }
}

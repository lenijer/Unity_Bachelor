using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Element : MonoBehaviour
{
    public GameObject SpawnLoc;
    //public GameObject Element;
    public GameObject spawnElementDefault;
    public GameObject spawnElectronDefault;

    public void SpawnElemant()
    {
        /*GameObject spawnedObject = Instantiate(Element);
        spawnedObject.transform.position = SpawnLoc.position;
        spawnedObject.transform.position += Vector3.up * 1;*/

        //GameObject spawnNew = new GameObject();
        //spawnNew = spawnElementDefault;

        GameObject spawnedObject = Instantiate(spawnElementDefault);

        RawImage img = this.GetComponent<RawImage>();

        spawnedObject.name = this.name;


        //spawnElementDefault.material = new Material(img.Texture);
        Material mat = new Material(Shader.Find("Standard"));
        mat.mainTexture =  img.texture;
        spawnedObject.GetComponent<MeshRenderer>().material = mat;

        Atom atm = this.GetComponent<Atom>();
        spawnedObject.GetComponent<AtomBehaviour>().atomic = atm;

        //spawnedObject.transform.position = SpawnLoc.transform.position;
        Vector3 offset = new Vector3(0.3f * Mathf.Sin(this.transform.rotation.y), 0, 0.3f * Mathf.Cos(this.transform.rotation.y));
        spawnedObject.transform.position += offset * (-1);
    }
}

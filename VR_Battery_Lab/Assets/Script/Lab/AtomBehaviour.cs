using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AtomBehaviour : MonoBehaviour
{
    public Atom atomic;
    public GameObject labelPrefab;
    public GameObject electronPrefab;
    public Vector3 Offset = new Vector3(0f, 0f, 0f);
    public float orbitDistance = 0.1f;
    public GameObject parent_pref;

    private GameObject parent;
    private bool hasparent = false;

    // Start is called before the first frame update
    void Start()
    {
        ShowLabel(); 
        GenerateElectrons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.tag == "Atom")
        {
            Treat_collision(collider);
        }
    }

    private void Treat_collision(GameObject col)
    {
        //Debug.Log("still good");
        if (hasparent)
        {
            //Debug.Log("it it here");
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                if (getParent().name != col.GetComponent<AtomBehaviour>().getParent().name)
                {

                }

            }else {
                this.parent.GetComponent<Molecule>().AddChild(col);
            }
        }
        else
        {
            if (col.GetComponent<AtomBehaviour>().haveparent())
            {
                //Debug.Log("it it here");
                col.GetComponent<AtomBehaviour>().getParent().GetComponent<Molecule>().AddChild(this.gameObject);
            }
            else
            {
                //Debug.Log("or here");
                Vector3 changes;
                changes = this.gameObject.transform.position;

                GameObject parent_obj = Instantiate(parent_pref);
                parent_obj.name = atomic.identifier + col.GetComponent<AtomBehaviour>().atomic.identifier;
                parent_obj.transform.position = changes + new Vector3(0,-0.1f,0);
                //Debug.Log("j");

                //this.gameObject.transform.position = Vector3.one * (0.1f);
                parent_obj.GetComponent<Molecule>().AddChild(this.gameObject);
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //Debug.Log(this.name);
                //Debug.Log("a");
                //col.transform.position = Vector3.one * (-0.1f);
                parent_obj.GetComponent<Molecule>().AddChild(col);
                col.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                //Debug.Log(col.name);
                //Debug.Log("b");

                //parent_obj.transform.position = changes;
                //Debug.Log("c");
            }
        }
    }

    public bool haveparent()
    {
        return hasparent;
    }

    public void setParent(GameObject p)
    {
        parent = p;
        hasparent = true;
        //this.gameObject.transform.SetParent(p.transform);
        //Debug.Log(this.name);
        GetComponent<XRGrabInteractable>().enabled = false;
    }

    public GameObject getParent()
    {
        return parent;
    }

    void ShowLabel()
    {
        var lab = Instantiate(labelPrefab, transform.position, Quaternion.identity, transform);
        lab.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.identifier;
        lab.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.value.ToString();
        lab.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.atom_name;
        lab.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = atomic.mass.ToString();
        lab.gameObject.transform.SetParent(this.gameObject.transform);
    }

    void GenerateElectrons()
    {
        int count = atomic.value;
        //float tempDistance = 0.1f;

        //for (int i = 0; i < count; i++)
        //{
        //    if (i < 2)
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 2) * i);
        //    }
        //    else if (i < 10)
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance * 2;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 8) * i);
        //    }
        //    else if (i < 28) 
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance * 3;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 18) * i);
        //    }
        //    else if (i < 60) 
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance * 4;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 32) * i);
        //    }
        //    else if (i < 110)
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance * 5;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 50) * i);
        //    }
        //    else
        //    {
        //        GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
        //        el.GetComponent<ElectronOrbit>().orbitDistance = tempDistance * 6;
        //        el.gameObject.transform.SetParent(this.gameObject.transform);
        //        el.transform.RotateAround(this.transform.position, Vector3.up, (360.0f / 8) * i);
        //    }
        //}

        float tempdistance = orbitDistance;
        if (count > 2)
        {   addElectron(2);
            count -= 2;}
        else 
        {   addElectron(count); 
            return; }

        orbitDistance = tempdistance * 2;
        if (count > 8)
        {   addElectron(8);
            count -= 8;}
        else
        {   addElectron(count);
            return; }

        orbitDistance = tempdistance * 3;
        if (count > 18)
        {   addElectron(18);
            count -= 18;}
        else
        {   addElectron(count);
            return; }

        orbitDistance = tempdistance * 4;
        if (count > 32)
        {   addElectron(32);
            count -= 32;}
        else
        {   addElectron(count);
            return; }

        orbitDistance = tempdistance * 5;
        if (count > 50)
        {   addElectron(50);
            count -= 50;}
        else
        {   addElectron(count);
            return; }

        orbitDistance = tempdistance * 6;
        addElectron(count);

    }

    void addElectron (int index)
    {
        float angleStep = 360.0f / index;
        for (int i = 0; i < index; i++)
        {
            GameObject el = Instantiate(electronPrefab, transform.position, Quaternion.identity, transform);
            el.GetComponent<ElectronOrbit>().orbitDistance = orbitDistance;
            el.gameObject.transform.SetParent(this.gameObject.transform);
            el.transform.RotateAround(this.transform.position, Vector3.up, angleStep * i);
        }
    }
}

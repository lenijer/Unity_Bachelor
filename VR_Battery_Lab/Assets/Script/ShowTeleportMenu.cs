using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTeleportMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuHolder;
    public Vector3 Offset;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XR_Origin")
        {
            Menu.transform.position = MenuHolder.transform.position + Offset;
            Menu.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Menu.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rigthGrabRay;

    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rigthDirectGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
        rigthGrabRay.SetActive(rigthDirectGrab.interactablesSelected.Count == 0);
    }
}

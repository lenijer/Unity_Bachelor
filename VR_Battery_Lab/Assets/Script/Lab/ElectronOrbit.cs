using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 45;
    [SerializeField] private float orbitDistance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Orbit()
    {
        // Keep us at orbitDistance from target
        transform.position = transform.parent.position + (transform.position - transform.parent.position).normalized * orbitDistance;

        transform.RotateAround(transform.parent.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Orbit();
    }

    // Call from LateUpdate if you want to be sure your
    // target is done with it's move.
    void LateUpdate()
    {
        //Orbit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 45;
    [SerializeField] private float orbitDistance = 0.2f;
    private Vector3 realativeDistance = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.parent.position + transform.forward * 0.5f;
        realativeDistance = transform.position - transform.parent.position;
    }

    void Orbit()
    {
        // Keep us at orbitDistance from target
        transform.position = transform.parent.position + realativeDistance;

        transform.RotateAround(transform.parent.position, Vector3.up, degreesPerSecond * Time.deltaTime);

        realativeDistance = transform.position - transform.parent.position;
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
        Orbit();
    }
}

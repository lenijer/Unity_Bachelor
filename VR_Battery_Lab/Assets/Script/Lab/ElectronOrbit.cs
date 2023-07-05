using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 45;   //  How fast we orbit
    public float orbitDistance = 0.2f;                      //  How far we orbit
    public Vector3 orbitRotation = Vector3.up;              //  How we orbit, i.e. yar, pitch, roll
    private Vector3 realativeDistance = Vector3.zero;       //  Orbit position calculation to maintain distance

    // Start is called before the first frame update
    void Start()
    {
        //  Moves the object orbitDistance away from the parent to get our wanted distance
        transform.position = transform.parent.position + transform.forward * orbitDistance;
        //  Updates relativeDistance for future calculations
        realativeDistance = transform.position - transform.parent.position;
    }

    void Orbit()
    {
        //  Keeps us at orbitDistance from target
        transform.position = transform.parent.position + realativeDistance;

        //  Rotates around the parent object
        transform.RotateAround(transform.parent.position, orbitRotation, degreesPerSecond * Time.deltaTime);

        //  Updates relativeDistance for future calculations
        realativeDistance = transform.position - transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Call from LateUpdate if you want to be sure your
    // target is done with it's move.
    void LateUpdate()
    {
        Orbit();
    }
}

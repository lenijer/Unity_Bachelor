using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 45;
    public float orbitDistance = 0.2f;
    public Vector3 orbitRotation = Vector3.up;
    private Vector3 realativeDistance = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 away = (Vector3.one - orbitRotation);
        //transform.position = transform.parent.position + away.normalized * orbitDistance;
        transform.position = transform.parent.position + transform.forward * orbitDistance;
        realativeDistance = transform.position - transform.parent.position;
    }

    void Orbit()
    {
        // Keep us at orbitDistance from target
        transform.position = transform.parent.position + realativeDistance;

        transform.RotateAround(transform.parent.position, orbitRotation, degreesPerSecond * Time.deltaTime);

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

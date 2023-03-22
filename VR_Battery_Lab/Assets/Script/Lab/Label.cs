using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour
{
    //public Transform head;
    public Vector3 Offset = new Vector3 (0f, 0f, 0f);
    public float OffsetF = 0.5f;
    Transform head;

    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.Find("Main Camera").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Atom atm = this.GetComponent<Atom>();
        transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        transform.forward *= -1;
        transform.position = transform.parent.position + transform.forward * OffsetF;
        
    }
}

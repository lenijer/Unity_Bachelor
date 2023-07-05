using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour
{
    public Vector3 Offset = new Vector3 (0f, 0f, 0f);   //  Vector direction for offset
    public float OffsetF = 0.5f;                        //  Float distance for offset
    Transform head;                                     //  Referance to the main camera attathced to the player

    // Start is called before the first frame update
    void Start()
    {
        //  Finding the "Head" main camera that the player see through
        head = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        //  Transform the label to look at the player
        transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        //  Flip the label around so it faces the player properly
        transform.forward *= -1;
        //  Move the label so that it floats slightly in front of the parent
        transform.position = transform.parent.position + transform.forward * OffsetF;
    }
}

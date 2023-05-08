using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo : MonoBehaviour
{
    public bool IsOccupied = false;
    public Transform Player;
    public Transform Menu;

    void OnTriggerExit(Collider collision)
    {
        GameObject collider;
        collider = collision.gameObject;
        if (collider.layer == 8)
        {
            IsOccupied = false;
        }
        //Debug.Log(collision.name + " has left the building");
    }

    void Update()
    {
        /*Vector3 Middle = new Vector3(0f, 0f, 0f);
        Middle.x = Player.position.x - Menu.position.x;
        Middle.z = Player.position.z - Menu.position.z;
        Middle = Middle / 2;
        //Middle.y = Player.position.y;
        Middle += Player.position;
        //Middle.x += Player.position.x;
        //Middle.z += Player.position.z;
        this.transform.position = Middle;*/
    }
}

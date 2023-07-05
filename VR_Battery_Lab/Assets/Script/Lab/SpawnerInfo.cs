using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo : MonoBehaviour
{
    public bool IsOccupied = false;         //Holds a variable to check if there is an object inside it's hitbox
    public Transform Player;                //Holds the information on where the player is (might not be nessesary)
    public Transform Menu;                  //Holds the informationon where the meny is (might also not be nessesary)

    void OnTriggerExit(Collider collision)
    {
        GameObject collider;
        collider = collision.gameObject;    //Changes the collision detection to get the object it collides with
        if (collider.layer == 8)
        {
            IsOccupied = false;             //Stops it beeing occupied as the corresponding object leaves the collider
        }
    }

    void Update()
    {

    }
}

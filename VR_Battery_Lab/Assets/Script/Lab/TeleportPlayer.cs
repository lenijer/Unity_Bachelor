using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] TeleportPads;
    public GameObject self;

    private Dropdown m_Dropdown;

    void Start()
    {
        try
        {
            m_Dropdown = self.GetComponent<Dropdown>();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("No Dropdown");
        }
    }

    public void TelePort()
    {
        int m_DropdownValue;
        m_DropdownValue = m_Dropdown.value;
        //Debug.Log(m_DropdownValue);
        Player.transform.position = TeleportPads[m_DropdownValue].transform.position;
    }
}

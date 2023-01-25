using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animate_HandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimAction;
    public InputActionProperty gripAnimAction;

    public Animator HandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggervalue = pinchAnimAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Trigger", triggervalue);

        float gripvalue = gripAnimAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Grip", gripvalue);
    }
}

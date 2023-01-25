using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInterractableTwoAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left_Hand"))
        {
            attachTransform = leftAttachTransform;
        }else if (args.interactorObject.transform.CompareTag("Right_Hand"))
        {
            attachTransform = rightAttachTransform;
        }


        base.OnSelectEntered(args);
    }
}

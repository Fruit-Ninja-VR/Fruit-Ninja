using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HandsController : MonoBehaviour
{
    public InputActionReference selectValue;
    public InputActionReference activateValue;

    //private ActionBasedController targetDevice;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = this.GetComponent<Animator>();
        //targetDevice = gameObject.GetComponentInParent<ActionBasedController>();
        //targetDevice = rightHand.GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        handAnimator.SetFloat("Grip", selectValue.action.ReadValue<float>());
        handAnimator.SetFloat("Trigger", activateValue.action.ReadValue<float>());
    }
}

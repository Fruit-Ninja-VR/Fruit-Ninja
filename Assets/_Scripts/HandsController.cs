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
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the values of the grip and trigger button which are all between 0-1
        handAnimator.SetFloat("Grip", selectValue.action.ReadValue<float>());
        handAnimator.SetFloat("Trigger", activateValue.action.ReadValue<float>());
    }
}

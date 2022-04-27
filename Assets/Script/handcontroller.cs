using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handcontroller : MonoBehaviour
{
    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;

    Animator handAnimtor;

    private void Awake()
    {
        handAnimtor = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripInputAction.action.performed += GripPressed;
        triggerInputAction.action.performed += TriggerPressed;

    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        handAnimtor.SetFloat("Trigger", obj.ReadValue<float>());

    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        handAnimtor.SetFloat("Grip", obj.ReadValue<float>());

    }

    private void OnDisable()
    {
        gripInputAction.action.performed -= GripPressed;
        triggerInputAction.action.performed -= TriggerPressed;
    }
}

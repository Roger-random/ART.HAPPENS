using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorBehaviors : MonoBehaviour
{
    public InputActionAsset playerControls;
    public InputAction fireAction;
    public AddObject refAddObject;

    public void Awake()
    {
        InputActionMap inputActionMap = playerControls.FindActionMap("Player");

        fireAction = inputActionMap.FindAction("Fire");
        fireAction.performed += FireAction_performed;
    }

    private void FireAction_performed(InputAction.CallbackContext obj)
    {
        refAddObject.Add();
    }

    public void OnEnable()
    {
        fireAction.Enable();
    }

    public void OnDisable()
    {
        fireAction.Disable();
    }
}

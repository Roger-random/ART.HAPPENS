using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenNewScrewdriver : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenNewScrewdriverJS();

    public InputActionAsset uiControls;
    public InputAction clickAction;

    public void Awake()
    {
        InputActionMap inputActionMap = uiControls.FindActionMap("UI");

        clickAction = inputActionMap.FindAction("Click");
        clickAction.performed += ClickAction_performed;
    }

    private void ClickAction_performed(InputAction.CallbackContext obj)
    {
        OpenNewScrewdriverJS();
    }

    private void OnEnable()
    {
        clickAction.Enable();
    }

    private void OnDisable()
    {
        clickAction.Disable();
    }
}

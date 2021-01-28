using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorBehaviors : MonoBehaviour
{
    public InputActionAsset playerControls;
    public InputAction tiltAction;

    public void Awake()
    {
        InputActionMap inputActionMap = playerControls.FindActionMap("Player");

        tiltAction = inputActionMap.FindAction("Move");
        tiltAction.performed += TiltAction_performed;
    }

    private void TiltAction_performed(InputAction.CallbackContext obj)
    {
        Vector2 tilt = obj.ReadValue<Vector2>();

        if (tilt.x < -0.5)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 5);
        }
        else if (tilt.x > 0.5)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -5);
        }
        else if (tilt.y < -0.5)
        {
            gameObject.transform.rotation = Quaternion.Euler(-5, 0, 0);
        }
        else if (tilt.y > 0.5)
        {
            gameObject.transform.rotation = Quaternion.Euler(5, 0, 0);
        }
    }

    public void OnEnable()
    {
        tiltAction.Enable();
    }

    public void OnDisable()
    {
        tiltAction.Disable();
    }
}

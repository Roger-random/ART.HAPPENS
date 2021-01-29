using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WooshControl : MonoBehaviour
{
    public InputActionAsset playerControls;

    public GameObject tailLeft;
    public GameObject tailRight;
    public AudioSource wooshSound;

    public InputAction moveAction;
    public InputAction fireAction;

    private bool tailIsLeft;

    // Start is called before the first frame update
    void Start()
    {
        InputActionMap inputActionMap = playerControls.FindActionMap("Player");

        moveAction = inputActionMap.FindAction("Move");
        moveAction.performed += MoveAction_performed;

        fireAction = inputActionMap.FindAction("Fire");
        fireAction.performed += FireAction_performed;

        tailIsLeft = true;
        tailLeft.SetActive(true);
        tailRight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            ToggleTail();
        }
    }

    public void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }

    private void FireAction_performed(InputAction.CallbackContext obj)
    {
        ToggleTail();
    }

    private void ToggleTail()
    {
        if (tailIsLeft)
        {
            MoveTailRight();
        }
        else
        {
            MoveTailLeft();
        }
    }

    private void MoveTailLeft()
    {
        tailIsLeft = true;
        tailLeft.SetActive(true);
        tailRight.SetActive(false);
        PlayWooshSound();
    }

    private void MoveTailRight()
    {
        tailIsLeft = false;
        tailLeft.SetActive(false);
        tailRight.SetActive(true);
        PlayWooshSound();
    }

    private void PlayWooshSound()
    {
        wooshSound.PlayOneShot(wooshSound.clip, 1.0f);
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        Vector2 direction = obj.ReadValue<Vector2>();

        if (direction.x < -0.5 && !tailIsLeft)
        {
            MoveTailLeft();
        }
        else if (direction.x > 0.5 && tailIsLeft)
        {
            MoveTailRight();
        }
    }

}

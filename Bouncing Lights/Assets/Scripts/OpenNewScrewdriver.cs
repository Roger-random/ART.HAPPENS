using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class OpenNewScrewdriver : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenNewScrewdriverJS();

    public InputActionAsset uiControls;
    public InputAction clickAction;
    public Light spotLight;
    public float highlightIntensity;
    public float highlightRate;
    private float normalLightIntensity;
    private Collider urlCollider;

    public void Awake()
    {
        InputActionMap inputActionMap = uiControls.FindActionMap("UI");

        clickAction = inputActionMap.FindAction("Click");
        clickAction.performed += ClickAction_performed;

        urlCollider = GetComponent<Collider>();

        normalLightIntensity = spotLight.intensity;
    }

    private void ClickAction_performed(InputAction.CallbackContext obj)
    {
        // Only open https://newscrewdriver.com when mouse click is on URL
        if (MouseHitTest())
        {
            OpenNewScrewdriverJS();
        }
    }

    private void OnEnable()
    {
        clickAction.Enable();
    }

    private void OnDisable()
    {
        clickAction.Disable();
    }

    private void Update()
    {
        // Highlight when mouse is over URL, but make the spotlight gradually fade from one intensity to another.
        if (MouseHitTest())
        {
            spotLight.intensity = Mathf.MoveTowards(spotLight.intensity, highlightIntensity, highlightRate * Time.deltaTime);
        }
        else
        {
            spotLight.intensity = Mathf.MoveTowards(spotLight.intensity, normalLightIntensity, highlightRate * Time.deltaTime);
        }
    }

    // This feels WAAAAAY more complicated than it needed to be. There's probably a
    // better way to do this but I don't know it yet.
    private bool MouseHitTest()
    {
        Vector2Control mousev2c = Mouse.current.position;
        Vector3 mousePosition = new Vector3(mousev2c.x.ReadValue(), mousev2c.y.ReadValue(), 0);
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        return urlCollider.Raycast(mouseRay, out hit, 100f);
    }
}

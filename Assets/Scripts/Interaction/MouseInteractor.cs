using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 5f;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
            {
                InteractableButton button = hit.collider.GetComponent<InteractableButton>();

                if (button != null)
                {
                    button.Press();
                }

                TemperatureTarget target = hit.collider.GetComponent<TemperatureTarget>();

                if (target != null)
                {
                    target.Interact();
                }

                ReturnZone returnZone =
                hit.collider.GetComponent<ReturnZone>();

                if (returnZone != null)
                {
                    returnZone.Interact();
                }

                SaturationTarget saturationTarget =
                hit.collider.GetComponent<SaturationTarget>();

                if (saturationTarget != null)
                {
                    saturationTarget.Interact();
                }

                BloodPressureTarget bloodPressureTarget =
                hit.collider.GetComponent<BloodPressureTarget>();

                if (bloodPressureTarget != null)
                {
                    bloodPressureTarget.Interact();
                }
            }
        }
    }
}
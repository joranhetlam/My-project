using UnityEngine;

public class ReturnZone : MonoBehaviour
{
    [SerializeField] private PickupObject pickupObject;
    [SerializeField]
    private MedicalToolDisplay toolDisplay;

    public void Interact()
    {
        pickupObject.ReturnToStart();

        GameManager.Instance.ClearSelectedTool();

        Debug.Log("Thermometer teruggelegd.");

        toolDisplay.ResetDisplay();
    }
}
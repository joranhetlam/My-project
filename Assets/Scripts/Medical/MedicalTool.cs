using UnityEngine;

public class MedicalTool : MonoBehaviour
{
    public enum ToolType
    {
        Thermometer,
        BloodPressure,
        PulseOximeter
    }

    [SerializeField]
    private ToolType toolType;

    public ToolType Type => toolType;

    public void Select()
    {
        GameManager.Instance.SelectTool(this);

        PickupObject pickup =
            GetComponent<PickupObject>();

        pickup.Pickup(GameManager.Instance.HandPoint);

        InformationBoardController.Instance.ToolSelected(toolType.ToString());

        Debug.Log(toolType + " geselecteerd.");
    }
}
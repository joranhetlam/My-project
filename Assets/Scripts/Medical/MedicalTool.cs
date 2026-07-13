using UnityEngine;

public class MedicalTool : MonoBehaviour
{
    public enum ToolType
    {
        Thermometer,
        BloodPressure,
        PulseOximeter
    }

    [SerializeField] private ToolType toolType;

    public ToolType Tool => toolType;
}
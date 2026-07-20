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

    [SerializeField]
    private AudioSource audioSource;

    public void Select()
    {
        GameManager.Instance.SelectTool(this);

        PickupObject pickup =
            GetComponent<PickupObject>();

        pickup.Pickup(GameManager.Instance.HandPoint);

        InformationBoardController.Instance.ToolSelected(toolType.ToString());

        Debug.Log(toolType + " geselecteerd.");
    }

    public void PlayMeasurementSound()
    {
        if (GameManager.Instance.CurrentMode == GameMode.Exam)
            return;

        if (audioSource != null)
            audioSource.Play();
    }
}
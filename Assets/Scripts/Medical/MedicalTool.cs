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
        Debug.Log("Geluid afspelen");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is null!");
            return;
        }

        Debug.Log($"Clip: {audioSource.clip}");
        Debug.Log($"Enabled: {audioSource.enabled}");
        Debug.Log($"GameObject active: {audioSource.gameObject.activeInHierarchy}");

        audioSource.Play();

        Debug.Log($"Is playing: {audioSource.isPlaying}");
    }
}
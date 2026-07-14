using UnityEngine;

public class PatientInteraction : MonoBehaviour
{
    public void Interact()
    {
        if (GameManager.Instance.SelectedTool == null)
        {
            Debug.Log("Geen hulpmiddel geselecteerd.");

            return;
        }

        if (GameManager.Instance.SelectedTool.Type ==
            MedicalTool.ToolType.Thermometer)
        {
            InformationBoardController.Instance.TemperatureFinished();

            Debug.Log("Temperatuur gemeten.");
        }
    }
}
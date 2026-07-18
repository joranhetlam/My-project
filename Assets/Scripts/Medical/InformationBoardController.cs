using TMPro;
using UnityEngine;

public class InformationBoardController : MonoBehaviour
{
    public static InformationBoardController Instance;

    [Header("Text")]
    public TMP_Text InstructionText;
    public TMP_Text StatusText;

    private bool temperatureDone;
    private bool saturationDone;
    private bool bloodPressureDone;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowDefault();
    }

    public void ShowDefault()
    {
        InstructionText.text =
            "Opdracht\n\n" +
            "Meet de vitale functies.\n\n" +
            "Selecteer eerst een hulpmiddel.";

        UpdateStatus();
    }

    public void ToolSelected(string toolName)
    {
        InstructionText.text =
            toolName +
            " geselecteerd.\n\n" +
            "Loop naar de patiënt.";
    }

    public void ShowCountdown(float seconds)
    {
        InstructionText.text =
            "Temperatuur meten...\n\n" +
            Mathf.CeilToInt(seconds);
    }

    public void TemperatureFinished(float value)
    {
        temperatureDone = true;

        InstructionText.text =
            "Temperatuur gemeten!\n\n" +
            value.ToString("0.0") + " °C";

        GameManager.Instance.TemperatureFinished = true;

        UpdateStatus();
        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    public void SaturationFinished(float value)
    {
        saturationDone = true;

        InstructionText.text =
            "Saturatie gemeten!\n\n98 %";

        GameManager.Instance.SaturationFinished = true;

        UpdateStatus();
        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    public void BloodPressureFinished(string value)
    {
        bloodPressureDone = true;

        InstructionText.text =
            "Bloeddruk gemeten!\n\n120 / 80";

        GameManager.Instance.BloodPressureFinished = true;

        UpdateStatus();
        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    private void UpdateStatus()
    {
        StatusText.text =
            "Status\n\n" +
            (temperatureDone ? "[X]" : "[ ]") + " Temperatuur\n" +
            (saturationDone ? "[X]" : "[ ]") + " Saturatie\n" +
            (bloodPressureDone ? "[X]" : "[ ]") + " Bloeddruk\n";
    }
}
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
        ResetBoard();

        if (GameManager.Instance.CurrentMode == GameMode.Practice)
        {
            ShowDefault();
        }
        else
        {
            ShowExamBoard(300f);
        }
    }

    public void ResetBoard()
    {
        temperatureDone = false;
        saturationDone = false;
        bloodPressureDone = false;

        InstructionText.text = "";

        UpdateStatus();
    }

    public void ShowDefault()
    {
        InstructionText.text =
            "Opdracht\n\n" +
            "Meet de vitale functies.\n\n" +
            "Selecteer eerst een hulpmiddel.";

        UpdateStatus();
    }

    public void ShowExamBoard(float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        InstructionText.text =
            "EXAM\n\n" +
            "Tijd resterend\n\n" +
            minutes.ToString("00") + ":" + seconds.ToString("00");

        StatusText.text =
            "Meet:\n\n" +
            "• Temperatuur\n" +
            "• Saturatie\n" +
            "• Bloeddruk";
    }

    public void ToolSelected(string toolName)
    {
        if (GameManager.Instance.CurrentMode == GameMode.Exam)
            return;

        InstructionText.text =
            toolName +
            " geselecteerd.\n\n" +
            "Loop naar de patiënt.";
    }

    public void ShowCountdown(float seconds)
    {
        if (GameManager.Instance.CurrentMode == GameMode.Exam)
            return;

        InstructionText.text =
            "Temperatuur meten...\n\n" +
            seconds;
    }

    public void TemperatureFinished(float value)
    {
        temperatureDone = true;

        GameManager.Instance.TemperatureFinished = true;

        if (GameManager.Instance.CurrentMode == GameMode.Practice)
        {
            InstructionText.text =
                "Temperatuur gemeten!\n\n" +
                value.ToString("0.0") + " °C";
        }

        UpdateStatus();
        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    public void SaturationFinished(float value)
    {
        saturationDone = true;

        GameManager.Instance.SaturationFinished = true;

        if (GameManager.Instance.CurrentMode == GameMode.Practice)
        {
            InstructionText.text =
                "Saturatie gemeten!\n\n98 %";
        }

        UpdateStatus();

        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    public void BloodPressureFinished(string value)
    {
        bloodPressureDone = true;

        GameManager.Instance.BloodPressureFinished = true;

        if (GameManager.Instance.CurrentMode == GameMode.Practice)
        {
            InstructionText.text =
            "Bloeddruk gemeten!\n\n120 / 80";
        }

        UpdateStatus();

        if (GameManager.Instance.TrainingFinished())
        {
            TrainingCompleteController.Instance.ShowTrainingComplete();
        }
    }

    private void UpdateStatus()
    {
        if (GameManager.Instance.CurrentMode == GameMode.Exam)
            return;

        StatusText.text =
            "Status\n\n" +
            (temperatureDone ? "[X]" : "[ ]") + " Temperatuur\n" +
            (saturationDone ? "[X]" : "[ ]") + " Saturatie\n" +
            (bloodPressureDone ? "[X]" : "[ ]") + " Bloeddruk\n";
    }

    private void ResetDefault()
    {
        temperatureDone = false;
        saturationDone = false;
        bloodPressureDone = false;

        UpdateStatus();
    }
}
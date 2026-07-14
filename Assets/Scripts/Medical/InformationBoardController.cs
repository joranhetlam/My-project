using TMPro;
using UnityEngine;

public class InformationBoardController : MonoBehaviour
{
    public static InformationBoardController Instance;

    [Header("Text")]
    public TMP_Text InstructionText;
    public TMP_Text StatusText;

    private bool temperatureDone;

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

    public void TemperatureFinished()
    {
        InstructionText.text =
            "Temperatuur gemeten.\n\n" +
            "Resultaat: 36.8 °C";

        temperatureDone = true;

        UpdateStatus();
    }

    private void UpdateStatus()
    {
        StatusText.text =
            "Status\n\n" +
            (temperatureDone ? "[X]" : "[]") + " Temperatuur\n" +
            "[] Saturatie\n" +
            "[] Bloeddruk";
    }
}
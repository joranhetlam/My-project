using TMPro;
using UnityEngine;

public class MedicalInteractionManager : MonoBehaviour
{
    public static MedicalInteractionManager Instance;

    [SerializeField] private TMP_Text instructionText;

    private MedicalTool selectedTool;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTool(MedicalTool tool)
    {
        selectedTool = tool;

        instructionText.text =
            tool.Tool + " geselecteerd.\n\nLoop naar de patiënt.";
    }

    public MedicalTool GetSelectedTool()
    {
        return selectedTool;
    }
}
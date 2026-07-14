using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    private InteractiveButtonVisual buttonVisual;
    private bool interactable = true;

    public void SetInteractable(bool value)
    {
        interactable = value;
    }

    private void Awake()
    {
        buttonVisual = GetComponent<InteractiveButtonVisual>();
    }

    public enum ButtonType
    {
        Practice,
        Exam,
        Start,
        MedicalTool,
        Patient
    }

    [SerializeField] private ButtonType buttonType;

    public ButtonType GetButtonType()
    {
        return buttonType;
    }

    public void Press()
    {
        if (!interactable)
        {
            Debug.Log("Knop is uitgeschakeld.");

            return;
        }

        switch (buttonType)
        {
            case ButtonType.Practice:
                MenuManager.Instance.SelectPractice();
                break;

            case ButtonType.Exam:
                MenuManager.Instance.SelectExam();
                break;

            case ButtonType.Start:
                MenuManager.Instance.StartTraining();
                break;

            case ButtonType.MedicalTool:

                MedicalTool tool = GetComponent<MedicalTool>();

                if (tool == null)
                {
                    Debug.LogError("MedicalTool component ontbreekt op " + gameObject.name);
                    return;
                }

                tool.Select();

                break;

            case ButtonType.Patient:

                PatientInteraction patient = GetComponent<PatientInteraction>();

                if (patient == null)
                {
                    Debug.LogError("PatientInteraction component ontbreekt op " + gameObject.name);
                    return;
                }

                patient.Interact();

                break;
        }
    }
}
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
        MedicalTool
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
        }
    }
}
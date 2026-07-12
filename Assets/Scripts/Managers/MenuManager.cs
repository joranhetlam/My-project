using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [Header("Beschrijving")]
    [SerializeField] private TextMeshPro descriptionText;

    [Header("Buttons")]
    [SerializeField] private InteractiveButtonVisual practiceButton;
    [SerializeField] private InteractiveButtonVisual examButton;
    [SerializeField] private InteractiveButtonVisual startButton;
    [SerializeField] private InteractableButton startInteractable;

    private void Awake()
    {
        Instance = this;

        practiceButton.SetDefault();
        examButton.SetDefault();
        startButton.SetDisabled();
        startInteractable.SetInteractable(false);
    }

    private void ResetButtons()
    {
        practiceButton.SetDefault();
        examButton.SetDefault();
    }

    public void SelectPractice()
    {
        ResetButtons();

        practiceButton.SetSelected();
        startButton.SetDefault();
        startInteractable.SetInteractable(true);

        GameManager.Instance.SetGameMode(GameMode.Practice);

        Debug.Log("Practice geselecteerd");

        descriptionText.text =
            "<b>OEFENMODUS</b>\n\n" +
            "• Hints beschikbaar\n" +
            "• Feedback tijdens oefenen\n" +
            "• Ideaal om vaardigheden te leren";
    }

    public void SelectExam()
    {
        ResetButtons();

        examButton.SetSelected();
        startButton.SetDefault();

        GameManager.Instance.SetGameMode(GameMode.Exam);

        Debug.Log("Exam geselecteerd");

        descriptionText.text =
            "<b>TOETSMODUS</b>\n\n" +
            "• Geen hints\n" +
            "• Zelfstandig handelen\n" +
            "• Feedback na afloop";
    }

    public void StartTraining()
    {
        Debug.Log("Training gestart");
    }
}
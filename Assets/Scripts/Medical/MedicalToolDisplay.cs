using TMPro;
using UnityEngine;

public class MedicalToolDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;

    [SerializeField]
    private string defaultText = "--";

    private void Start()
    {
        displayText.text = defaultText;
    }

    public void ShowValue(string value)
    {
        displayText.text = value;
    }

    public void ResetDisplay()
    {
        displayText.text = defaultText;
    }
}
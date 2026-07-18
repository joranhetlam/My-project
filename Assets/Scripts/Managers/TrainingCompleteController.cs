using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainingCompleteController : MonoBehaviour
{
    public static TrainingCompleteController Instance;

    [Header("UI")]
    [SerializeField] private GameObject trainingCompleteCanvas;
    [SerializeField] private TMP_Text completeText;

    [Header("Settings")]
    [SerializeField] private float countdownTime = 10f;
    [SerializeField] private string trainingHubScene = "TrainingHub";

    private bool trainingFinished;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowTrainingComplete()
    {
        if (trainingFinished)
            return;

        trainingFinished = true;

        trainingCompleteCanvas.SetActive(true);

        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        DisablePlayer();

        float timer = countdownTime;

        while (timer > 0)
        {
            completeText.text =
                "TRAINING VOLTOOID!\n\n" +
                "Je wordt teruggestuurd naar de TrainingHub...\n\n" +
                Mathf.Ceil(timer);

            timer -= Time.deltaTime;

            yield return null;
        }

        SceneManager.LoadScene(trainingHubScene);
    }

    private void DisablePlayer()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            MonoBehaviour[] scripts =
                player.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
    }
}
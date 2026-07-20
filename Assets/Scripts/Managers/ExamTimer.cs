using UnityEngine;

public class ExamTimer : MonoBehaviour
{
    [SerializeField]
    private float examDuration = 300f;

    private float timer;

    private bool running;

    private void Start()
    {
        if (GameManager.Instance.CurrentMode != GameMode.Exam)
            return;

        timer = examDuration;

        running = true;
    }

    private void Update()
    {
        Debug.Log(timer);
        if (!running)
            return;

        timer -= Time.deltaTime;

        InformationBoardController.Instance.ShowExamBoard(timer);

        if (timer <= 0)
        {
            running = false;

            TrainingCompleteController.Instance.ShowExamFailed();
        }
    }
}
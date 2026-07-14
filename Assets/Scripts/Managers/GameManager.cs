using UnityEngine;

public enum GameMode
{
    Practice,
    Exam
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameMode CurrentMode { get; private set; }
    public MedicalTool SelectedTool { get; private set; }
    public Transform HandPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CurrentMode = GameMode.Practice;
    }

    public void SetGameMode(GameMode mode)
    {
        CurrentMode = mode;

        Debug.Log("Gamemode ingesteld op: " + mode);
    }

    public void SelectTool(MedicalTool tool)
    {
        SelectedTool = tool;

        Debug.Log("Geselecteerd hulpmiddel: " + tool.Type);
    }

    public void ClearSelectedTool()
    {
        SelectedTool = null;
    }
}
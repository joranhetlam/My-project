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
}
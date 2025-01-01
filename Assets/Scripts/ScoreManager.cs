using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int DestroyedBlocksCount = 0; // Static score variable
    // Ensure this object persists across scenes
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Reset score when needed
    public static void ResetScore()
    {
        DestroyedBlocksCount = 0;
    }
    // Add to score
    public static void AddScore(int value)
    {
        DestroyedBlocksCount += value; 
    }
}












/*public static ScoreManager Instance; // Singleton instance
private int currentScore = 0;
[SerializeField] private TextMeshProUGUI scoreText; // Text element for displaying the score

private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }
    else
    {
        Destroy(gameObject); // Prevent duplicates
    }
}

private void Start()
{
    // Attempt to find a TextMeshProUGUI in the scene if not assigned
    if (scoreText == null)
    {
        GameObject scoreObject = GameObject.Find("Puntaje");
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    UpdateScoreUI();
}

public void AddScore(int points)
{
    currentScore += points;
    UpdateScoreUI();
}

public int GetScore()
{
    return currentScore;
}

public void ResetScore()
{
    currentScore = 0;
    UpdateScoreUI();
}

private void UpdateScoreUI()
{
    if (scoreText != null)
    {
        scoreText.text = $"Puntaje: {currentScore}";
    }
}*/

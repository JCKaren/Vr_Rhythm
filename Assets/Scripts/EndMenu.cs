using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    // Display the final score
    void Start()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = $"Final Score: {ScoreManager.DestroyedBlocksCount}";
        }
    }
    // Reset the score and return to the level
    public void RestartGame()
    {
        ScoreManager.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("WeWillRockYou");
    }
    // Quit the game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("user quit");
    }
}
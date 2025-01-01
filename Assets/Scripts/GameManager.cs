using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource music; 

    private void Update()
    {
        // Check if the music has stopped playing
        if (!music.isPlaying && music.time > 0)
        {
            // Transition to the EndMenu scene
            SceneManager.LoadScene("EndScene");
        }
    }
}

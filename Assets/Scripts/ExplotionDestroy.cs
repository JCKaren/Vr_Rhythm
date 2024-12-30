using UnityEngine;
using TMPro; // For TextMeshPro

public class ExplotionDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab; // Prefab for explosion
    [SerializeField] private TextMeshProUGUI destroyedBlocksText; // Reference to TextMeshProUGUI
    private static int destroyedBlocksCount = 0;

    private void Start()
    {
        // Dynamically find the TextMeshPro component if not assigned in the Inspector
        if (destroyedBlocksText == null)
        {
            GameObject puntajeObject = GameObject.Find("Puntaje");
            Debug.Log("Puntaje object found: " + puntajeObject); // Debug to check if Puntaje is found

            if (puntajeObject != null)
            {
                destroyedBlocksText = puntajeObject.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log("Found TextMeshProUGUI: " + destroyedBlocksText); // Debug to check if TextMeshProUGUI is found
            }
        }

        if (destroyedBlocksText == null)
        {
            Debug.LogError("Destroyed Blocks Text UI element not found! Ensure it's assigned or exists in the scene.");
        }
    }


    private void OnMouseDown()
    {
        // Destroy block on mouse click with an explosion effect
        DestroyObjectWithExplosion();
    }

    private void DestroyBlock()
    {
        // Increment the counter
        destroyedBlocksCount++;

        // Update the TextMeshProUGUI element
        if (destroyedBlocksText != null)
        {
            destroyedBlocksText.text = $"Destroyed Blocks: {destroyedBlocksCount} / 91";
        }

        // Destroy the GameObject
        Destroy(gameObject);
    }
    private void DestroyObjectWithExplosion()
    {
        // Instantiate explosion effect at the block's position
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1.8f); // Destroy explosion effect after 1.8 seconds
        }

        // Destroy the block and increment the counter
        DestroyBlock();
    }
}

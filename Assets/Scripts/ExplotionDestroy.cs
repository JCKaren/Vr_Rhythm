
using UnityEngine;
using TMPro; // For TextMeshPro

public class ExplotionDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private TextMeshProUGUI destroyedBlocksText;
    private void OnTriggerEnter(Collider other)
    {
        // Si el cubo colisiona con un objeto con la etiqueta "Wall"
        if (other.gameObject.CompareTag("Wall"))
        {
            if (transform.parent != null)
            {
                // Destruye el objeto padre
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // Si no tiene padre, destruye solo este objeto
                Destroy(gameObject);
            }
        }
    }

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

    // Destroy block on mouse click with an explosion effect
    private void OnMouseDown()
    {
        DestroyObjectWithExplosion();
    }

    private void DestroyBlock()
    {
        ScoreManager.AddScore(1);
        // Update the TextMeshProUGUI element
        if (destroyedBlocksText != null)
        {
            destroyedBlocksText.text = $"Destroyed Blocks: {ScoreManager.DestroyedBlocksCount} / 91";
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
        if (transform.parent != null)
        {
            // Destruye el objeto padre
            Destroy(transform.parent.gameObject);
        }
        else
        {
            // Si no tiene padre, destruye solo este objeto
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplotionDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab; // Prefab de la explosión a instanciar

    private void OnTriggerEnter(Collider other)
    {
        // Si el cubo colisiona con un objeto con la etiqueta "Wall"
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        // Si se hace clic en el objeto, se destruye con el efecto de explosión
        DestroyObjectWithExplosion();
    }

    private void DestroyObjectWithExplosion()
    {
        // Instancia el efecto de explosión en la posición del objeto
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Inicia una corrutina para destruir la explosión cuando se complete
            StartCoroutine(DestroyExplosionAfterParticles(explosion));
        }

        // Verifica si el objeto tiene un padre
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

    // Corrutina para esperar a que las partículas terminen
    private IEnumerator DestroyExplosionAfterParticles(GameObject explosion)
    {
        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            // Espera hasta que el sistema de partículas se complete
            while (particleSystem.IsAlive())
            {
                yield return null; // Espera hasta el siguiente frame
            }
        }

        // Una vez que las partículas se han agotado, destruye el objeto de explosión
        Destroy(explosion);
    }
}

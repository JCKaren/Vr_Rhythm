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

            // Destruye la explosión después de un tiempo fijo (reemplaza 2f con la duración real de tu animación)
            Destroy(explosion, 1.8f);

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
        ParticleSystem[] particleSystems = explosion.GetComponentsInChildren<ParticleSystem>();

        if (particleSystems.Length > 0)
        {
            // Espera hasta que todos los sistemas de partículas hayan terminado
            foreach (var ps in particleSystems)
            {
                while (ps.IsAlive())
                {
                    yield return null; // Espera al siguiente frame
                }
            }
        }

        // Destruye el objeto de explosión

        Destroy(explosion);
    }
}

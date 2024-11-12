using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplotionDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab; // Prefab de la explosi�n a instanciar

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
        // Si se hace clic en el objeto, se destruye con el efecto de explosi�n
        DestroyObjectWithExplosion();
    }

    private void DestroyObjectWithExplosion()
    {
        // Instancia el efecto de explosi�n en la posici�n del objeto
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Inicia una corrutina para destruir la explosi�n cuando se complete
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

    // Corrutina para esperar a que las part�culas terminen
    private IEnumerator DestroyExplosionAfterParticles(GameObject explosion)
    {
        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            // Espera hasta que el sistema de part�culas se complete
            while (particleSystem.IsAlive())
            {
                yield return null; // Espera hasta el siguiente frame
            }
        }

        // Una vez que las part�culas se han agotado, destruye el objeto de explosi�n
        Destroy(explosion);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    void Start()
    {
        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
        }
    }

    void Update()
    {
        // Verifica si el número de partículas activas es cero
        if (particle != null && particle.particleCount == 0)
        {
            // Inicia la corrutina de autodestrucción después de 1.16 segundos
            StartCoroutine(DestroyAfterDelay(1.16f));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Destruye el objeto
        Destroy(gameObject);
    }
}

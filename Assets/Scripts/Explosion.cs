using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]private ParticleSystem particles;

    void Start()
    {
        // Obtener el componente ParticleSystem del objeto
        particles = GetComponent<ParticleSystem>();

        if (particles == null)
        {
            Debug.LogError("No se encontró un sistema de partículas en el objeto.");
            Destroy(gameObject); // Destruye el objeto si no tiene un ParticleSystem
            return;
        }
    }

    void Update()
    {
        // Verificar si el sistema de partículas ha terminado
        if (!particles.IsAlive())
        {
            Destroy(gameObject); // Elimina el objeto de la escena
        }
    }
}

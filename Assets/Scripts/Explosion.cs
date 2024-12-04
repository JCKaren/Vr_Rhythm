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
            Debug.LogError("No se encontr� un sistema de part�culas en el objeto.");
            Destroy(gameObject); // Destruye el objeto si no tiene un ParticleSystem
            return;
        }
    }

    void Update()
    {
        // Verificar si el sistema de part�culas ha terminado
        if (!particles.IsAlive())
        {
            Destroy(gameObject); // Elimina el objeto de la escena
        }
    }
}

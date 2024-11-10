using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyT1 : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        // Si el cubo colisiona con un objeto con la etiqueta "Wall"
        // Si el cubo colisiona con un objeto con la etiqueta "Wall"
        if (other.gameObject.CompareTag("Wall"))
        {
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
    }
}

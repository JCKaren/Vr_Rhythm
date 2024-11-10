using UnityEngine;

public class QuadSpawner : MonoBehaviour
{
    public Transform[] objectsToSpawn; // Los objetos a generar (padres vac�os con cubos como hijos)
    private Vector3[] quadVertices;

    void Start()
    {
        // Obtener el mesh de Quad
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // Obtener las posiciones de los v�rtices del Quad en el espacio del mundo
        quadVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            quadVertices[i] = transform.TransformPoint(mesh.vertices[i]);
        }

        SpawnObjectsAtVertices();
    }

    void SpawnObjectsAtVertices()
    {
        // Generar los objetos en posiciones aleatorias de los v�rtices
        foreach (Transform obj in objectsToSpawn)
        {
            // Elegir una posici�n de v�rtice aleatoria
            int randomIndex = Random.Range(0, quadVertices.Length);
            Vector3 spawnPosition = quadVertices[randomIndex];

            // Instanciar el objeto en la posici�n seleccionada
            Instantiate(obj, spawnPosition, Quaternion.identity);
        }
    }
}

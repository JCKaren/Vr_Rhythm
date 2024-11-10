using UnityEngine;

public class QuadSpawner : MonoBehaviour
{
    public Transform[] objectsToSpawn; // Los objetos a generar (padres vacíos con cubos como hijos)
    private Vector3[] quadVertices;

    void Start()
    {
        // Obtener el mesh de Quad
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // Obtener las posiciones de los vértices del Quad en el espacio del mundo
        quadVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            quadVertices[i] = transform.TransformPoint(mesh.vertices[i]);
        }

        SpawnObjectsAtVertices();
    }

    void SpawnObjectsAtVertices()
    {
        // Generar los objetos en posiciones aleatorias de los vértices
        foreach (Transform obj in objectsToSpawn)
        {
            // Elegir una posición de vértice aleatoria
            int randomIndex = Random.Range(0, quadVertices.Length);
            Vector3 spawnPosition = quadVertices[randomIndex];

            // Instanciar el objeto en la posición seleccionada
            Instantiate(obj, spawnPosition, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1.0f; // Tiempo entre cada spawn

    [SerializeField] private GameObject Prefab1; // Prefabs a generar
    [SerializeField] private GameObject Prefab2;
    [SerializeField] private GameObject Prefab3;
    [SerializeField] private GameObject Prefab4;

    private List<Vector3> spawnPositions = new List<Vector3>();
    private List<GameObject> spawnPrefabs = new List<GameObject>();

    void Start()
    {
        // Inicializa las posiciones y los prefabs
        AddToListPositions(); // Asegúrate de llamar a esta función
        AddToListPrefabs();

        // Invoca el método SpawnCube repetidamente
        InvokeRepeating("SpawnCube", 0, spawnInterval);
    }

    void AddToListPrefabs() // Añade los prefabs a una lista
    {
        spawnPrefabs.Add(Prefab1);
        spawnPrefabs.Add(Prefab2);
        spawnPrefabs.Add(Prefab3);
        spawnPrefabs.Add(Prefab4);
    }

    void AddToListPositions()
    {
        spawnPositions.Add(new Vector3(-0.5f, 0.5f, 0));   // Izquierda arriba
        spawnPositions.Add(new Vector3(0.5f, 0.5f, 0));    // Derecha arriba
        spawnPositions.Add(new Vector3(-0.5f, -0.5f, 0));  // Izquierda abajo
        spawnPositions.Add(new Vector3(0.5f, -0.5f, 0));   // Derecha abajo
    }

    void SpawnCube()
    {
        int randomPositionIndex = Random.Range(0, spawnPositions.Count);
        int randomPrefabIndex = Random.Range(0, spawnPrefabs.Count);

        Vector3 spawnPosition = spawnPositions[randomPositionIndex];
        GameObject prefabToSpawn = spawnPrefabs[randomPrefabIndex];

        Debug.Log($"Generando prefab: {prefabToSpawn.name} en posición: {spawnPosition}");

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
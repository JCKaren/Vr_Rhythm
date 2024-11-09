using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     // Prefab del cubo
    [SerializeField] private float spawnInterval = 1.0f; // Tiempo entre cada spawn
    
    [Header("Inferior Izquierda")]    
    [SerializeField] private GameObject cubePrefab;

    [Header("Superior Izquierda")]
    [SerializeField] private GameObject cubePrefab2;

    [Header("Superior derecha")]
    [SerializeField] private GameObject cubePrefab3;

    [Header("Inferior derecha")]
    [SerializeField] private GameObject cubePrefab4;

    private List<Vector3> spawnPositions = new List<Vector3>();

    void Start()
    {
        // Inicializa las posiciones de las esquinas
        RandomGenerator();

        // Invoca el método SpawnCube repetidamente
        InvokeRepeating("SpawnCube", 0, spawnInterval);
    }

    void RandomGenerator()
    {
                 
            spawnPositions.Add(cubePrefab.transform.position); // Inferior izquierda
            spawnPositions.Add(cubePrefab2.transform.position); // Superior izquierda
            spawnPositions.Add(cubePrefab3.transform.position); // Superior derecha
            spawnPositions.Add(cubePrefab4.transform.position); // Inferior derecha            
    }

    void SpawnCube()
    {
        // Seleccionar una posición al azar de las esquinas
        int randomIndex = Random.Range(0, spawnPositions.Count);
        Vector3 spawnPosition = spawnPositions[randomIndex];

        // Instanciar el cubo en la posición seleccionada
        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
    }
}
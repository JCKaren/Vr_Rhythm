using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private List<GameObject> spawnPrefabs = new List<GameObject>(); 
    [SerializeField] private float spawnThreshold = 0.1f; 
    [SerializeField] private int spectrumIndex = 1; 
    [SerializeField] private float spawnInterval = 0.5f; 

    private List<Vector3> spawnPositions = new List<Vector3>(); 
    private float[] spectrumData = new float[64]; 
    private float lastSpawnTime;

    // Inicializa las posiciones y los prefabs
    void Start()
    {
        AddToListPositions();
    }

    void Update()
    {
        // Obtener datos de espectro del audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Verifica si el valor de frecuencia actual supera el umbral y si ha pasado el tiempo mínimo entre spawns
        if (spectrumData[spectrumIndex] > spawnThreshold && Time.time > lastSpawnTime + spawnInterval)
        {
            // Genera el prefab en sincronía con el ritmo y actualiza el tiempo del último spawn
            SpawnPrefab();
            lastSpawnTime = Time.time;
        }
    }

    void AddToListPositions()
    {
        spawnPositions.Add(new Vector3(-0.5f, 0.5f, 0));   // Izquierda arriba
        spawnPositions.Add(new Vector3(0.5f, 0.5f, 0));    // Derecha arriba
        spawnPositions.Add(new Vector3(-0.5f, -0.5f, 0));  // Izquierda abajo
        spawnPositions.Add(new Vector3(0.5f, -0.5f, 0));   // Derecha abajo
    }

    void SpawnPrefab()
    {
        // Selecciona una posición y un prefab aleatorios de las listas
        int randomPositionIndex = Random.Range(0, spawnPositions.Count);
        int randomPrefabIndex = Random.Range(0, spawnPrefabs.Count);

        Vector3 spawnPosition = spawnPositions[randomPositionIndex];
        GameObject prefabToSpawn = spawnPrefabs[randomPrefabIndex];

        // Instancia el prefab en la posición seleccionada
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log($"Prefab {prefabToSpawn.name} generado en posición {spawnPosition} en sincronía con el ritmo.");
 
    }
}
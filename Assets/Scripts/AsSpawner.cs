using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Fuente de audio
    [SerializeField] private List<GameObject> spawnPrefabs = new List<GameObject>(); // Lista de prefabs a generar
    [SerializeField] private float spawnThreshold = 0.1f; // Umbral de energ�a para generar el prefab
    [SerializeField] private int spectrumIndex = 1; // �ndice de frecuencia a monitorear (1 = bajo)
    [SerializeField] private float spawnInterval = 0.5f; // Intervalo m�nimo entre spawns

    private List<Vector3> spawnPositions = new List<Vector3>(); // Lista de posiciones de spawn
    private float[] spectrumData = new float[64]; // Array para los datos de espectro de frecuencia
    private float lastSpawnTime; // �ltimo tiempo de generaci�n para evitar spawns r�pidos

    void Start()
    {
        // Inicializa las posiciones y los prefabs
        AddToListPositions();
    }

    void Update()
    {
        // Obtener datos de espectro del audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Verifica si el valor de frecuencia actual supera el umbral y si ha pasado el tiempo m�nimo entre spawns
        if (spectrumData[spectrumIndex] > spawnThreshold && Time.time > lastSpawnTime + spawnInterval)
        {
            // Genera el prefab en sincron�a con el ritmo y actualiza el tiempo del �ltimo spawn
            SpawnPrefab();
            lastSpawnTime = Time.time;
        }
    }

    void AddToListPositions()
    {
        // A�ade las posiciones definidas al array
        spawnPositions.Add(new Vector3(-0.5f, 0.5f, 0));   // Izquierda arriba
        spawnPositions.Add(new Vector3(0.5f, 0.5f, 0));    // Derecha arriba
        spawnPositions.Add(new Vector3(-0.5f, -0.5f, 0));  // Izquierda abajo
        spawnPositions.Add(new Vector3(0.5f, -0.5f, 0));   // Derecha abajo
    }

    void SpawnPrefab()
    {
        // Selecciona una posici�n y un prefab aleatorios de las listas
        int randomPositionIndex = Random.Range(0, spawnPositions.Count);
        int randomPrefabIndex = Random.Range(0, spawnPrefabs.Count);

        Vector3 spawnPosition = spawnPositions[randomPositionIndex];
        GameObject prefabToSpawn = spawnPrefabs[randomPrefabIndex];

        // Instancia el prefab en la posici�n seleccionada
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log($"Prefab {prefabToSpawn.name} generado en posici�n {spawnPosition} en sincron�a con el ritmo.");
    }
}

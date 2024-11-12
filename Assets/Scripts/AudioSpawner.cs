using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Fuente de audio
    [SerializeField] private GameObject prefabToSpawn; // Prefab a generar
    [SerializeField] private float spawnThreshold = 0.1f; // Umbral de energía para generar el prefab
    [SerializeField] private int spectrumIndex = 1; // Índice de frecuencia a monitorear (1 = bajo)

    private float[] spectrumData = new float[64]; // Array para los datos de espectro de frecuencia
    private float lastSpawnTime; // Último tiempo de generación para evitar spawns rápidos

    void Update()
    {
        // Obtener datos de espectro del audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Verifica si el valor de frecuencia actual supera el umbral
        if (spectrumData[spectrumIndex] > spawnThreshold && Time.time > lastSpawnTime + 0.5f)
        {
            // Genera el prefab y actualiza el tiempo del último spawn
            SpawnPrefab();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnPrefab()
    {
        // Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Vector3 spawnPosition = new Vector3(0,0,0);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log("Prefab generado en sincronía con el ritmo.");
    }
}

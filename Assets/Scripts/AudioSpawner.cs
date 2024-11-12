using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Fuente de audio
    [SerializeField] private GameObject prefabToSpawn; // Prefab a generar
    [SerializeField] private float spawnThreshold = 0.1f; // Umbral de energ�a para generar el prefab
    [SerializeField] private int spectrumIndex = 1; // �ndice de frecuencia a monitorear (1 = bajo)

    private float[] spectrumData = new float[64]; // Array para los datos de espectro de frecuencia
    private float lastSpawnTime; // �ltimo tiempo de generaci�n para evitar spawns r�pidos

    void Update()
    {
        // Obtener datos de espectro del audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Verifica si el valor de frecuencia actual supera el umbral
        if (spectrumData[spectrumIndex] > spawnThreshold && Time.time > lastSpawnTime + 0.5f)
        {
            // Genera el prefab y actualiza el tiempo del �ltimo spawn
            SpawnPrefab();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnPrefab()
    {
        // Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        Vector3 spawnPosition = new Vector3(0,0,0);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log("Prefab generado en sincron�a con el ritmo.");
    }
}

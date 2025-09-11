using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject MagnetPrefab; // Drag your platform prefab here

    public float spawnInterval = 2f;  // Time between spawns

    public float spawnXMin = -5f;

    public float spawnXMax = 5f;

    public float spawnY = 10f;        // Spawn above the camera



    void Start()

    {

        InvokeRepeating("SpawnPlatform", 1f, spawnInterval);

    }



    void SpawnPlatform()

    {

        float randomX = Random.Range(spawnXMin, spawnXMax);

        Vector3 spawnPos = new Vector3(randomX, spawnY, 0);

        Instantiate(MagnetPrefab, spawnPos, Quaternion.identity);

    }

}

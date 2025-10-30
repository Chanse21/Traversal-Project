using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject MagnetPrefab; // Drag your platform prefab here

    public float spawnInterval = 2f;  // Time between spawns

    public float spawnXMin = -5f;

    public float spawnXMax = 5f;

    public float spawnYOffset = 10f;        // Spawn above the camera

    private Camera mainCam;

    void Start()

    {
        mainCam = Camera.main;

        InvokeRepeating(nameof(SpawnPlatform), 1f, spawnInterval);

    }



    void SpawnPlatform()

    {
        float camBottom = mainCam.transform.position.y - mainCam.orthographicSize;

        float randomX = Random.Range(spawnXMin, spawnXMax);

        Vector3 spawnPos = new Vector3(randomX, camBottom - spawnYOffset, 0);

        Instantiate(MagnetPrefab, spawnPos, Quaternion.identity);

    }

}

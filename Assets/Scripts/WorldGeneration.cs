using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject[] treePrefabs;
    public GameObject[] worldPrefabs; 
    public GameObject boundaryPrefab;
    public GameObject grassPrefab;
    public Transform chicken; 
    public GameObject log;
    public float spawnOffset = 21f;
    public int stripsSpawned = 0;
    // public float treeSpacingRadius = 1.5f;
    
    private bool lastWater = false;
    private int lastGeneratedZ = int.MinValue;

    void Start()
    {
        int[] grassPositions = { -2, -1, 0, 4, 5, 6, 8, 9, 11, 12 };
        for (int i = 0; i < grassPositions.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 position = new Vector3(Random.Range(-19, 19), 0.5f, grassPositions[i]);
                Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                Instantiate(grassPrefab, position, rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int currentZ = Mathf.FloorToInt(chicken.position.z);

        if (currentZ > lastGeneratedZ)
        {
            lastGeneratedZ = currentZ;

            GameObject prefab; 

            if (lastWater == true) {
                prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length - 1)];
                lastWater = false;

            }
            else
            {
                prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length)];
            }

            if (prefab.tag == "water")
            {
                lastWater = true;
                for (int i = 0; i < 4; i++)
                {
                    Vector3 logSpawnPosition = new Vector3(Random.Range(-19, 20), (float)0.3258734, currentZ + spawnOffset);
                    Instantiate(log, logSpawnPosition, Quaternion.Euler(90, 180, 0));
                    // Debug.Log("spawned log");
                }
            }

            // actually instantiate strip
            Vector3 spawnPosition = new Vector3(0, 0, currentZ + spawnOffset);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            Instantiate(boundaryPrefab, new Vector3(19.5f, 0.5f, currentZ + spawnOffset), Quaternion.identity);
            Instantiate(boundaryPrefab, new Vector3(-19.5f, 0.5f, currentZ + spawnOffset), Quaternion.identity);

            stripsSpawned++;
            if (stripsSpawned > 20)
            {
                // increase speed of lambdas;
                FindObjectOfType<lambdaSpawner>()?.IncreaseLambdaSpeed(1f);
                stripsSpawned = 0;
            }

            if (prefab.name == "RoadStrip")
            {
                lambdaSpawner lambdaSpawner = FindObjectOfType<lambdaSpawner>();
                lambdaSpawner.addZSpawnPosition(currentZ + (int)spawnOffset);
            }

            if (prefab.name == "GrassStrip")
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)];
                    Vector3 treeSpawnPosition = new Vector3(Mathf.RoundToInt(Random.Range(-19, 20)), 0, currentZ + spawnOffset);
                    Instantiate(randomTree, treeSpawnPosition, Quaternion.identity);
                    Debug.Log("spawned tree at " + treeSpawnPosition);

                    // Collider[] hitColliders = Physics.OverlapSphere(treeSpawnPosition, treeSpacingRadius);
                    //     if (hitColliders.Length == 0)
                    //     {
                    //         // no overlap
                    //         Instantiate(randomTree, treeSpawnPosition, Quaternion.identity);
                    //         break;
                    //     }

                }

                for (int i = 0; i < 10; i++)
                {
                    Vector3 position = new Vector3(Random.Range(-19, 19), 0.5f, currentZ + spawnOffset);
                    Quaternion rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                    Instantiate(grassPrefab, position, rotation);
                }
            }
        }
    }
}

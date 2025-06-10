using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject[] treePrefabs; // Assign in Inspector with 5 tree prefabs
    public GameObject[] worldPrefabs; // Assign your tile prefabs in the Inspector
    public Transform chicken;         // Assign the Chicken GameObject
    public float spawnOffset = 15f;   // How far ahead of the chicken to spawn tiles
    // public float treeSpacingRadius = 1.5f; // Minimum spacing between trees

    private int lastGeneratedZ = int.MinValue;

    // Update is called once per frame
    void Update()
    {
        int currentZ = Mathf.FloorToInt(chicken.position.z);

        if (currentZ > lastGeneratedZ)
        {
            lastGeneratedZ = currentZ;

            for (int i = 0; i < 4; i++){
                GameObject randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)];
                Vector3 treeSpawnPosition = new Vector3(Random.Range(-20, 20), 0, currentZ + spawnOffset);
                Instantiate(randomTree, treeSpawnPosition, Quaternion.identity);

                // Collider[] hitColliders = Physics.OverlapSphere(treeSpawnPosition, treeSpacingRadius);
                //     if (hitColliders.Length == 0)
                //     {
                //         // no overlap
                //         Instantiate(randomTree, treeSpawnPosition, Quaternion.identity);
                //         break;
                //     }

            }

            GameObject prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length)];

            Vector3 spawnPosition = new Vector3(0, 0, currentZ + spawnOffset);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            if(prefab.name == "RoadStrip"){
                lambdaSpawner lambdaSpawner = FindObjectOfType<lambdaSpawner>();
                lambdaSpawner.addZSpawnPosition(currentZ + (int)spawnOffset);
            }
        }
    }
}

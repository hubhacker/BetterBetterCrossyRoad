using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeSpawner : MonoBehaviour
{

    public GameObject[] treePrefabs; // Assign in Inspector with 5 tree prefabs
    public float spawnInterval = 1f; // Time between spawns
    public int[] zSpawnPositions = {1, 2, 4, 9};

    private void Start()
    {
        for (int i = 0; i < 4; i++){
            GameObject randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)];
            Vector3 spawnPosition = (Random.value < 0.5f) ?
                new Vector3(-10, 0, zSpawnPositions[i]) :
                new Vector3(10, 0, zSpawnPositions[i]);
            Instantiate(randomTree, spawnPosition, Quaternion.identity);
        }
        StartCoroutine(SpawnTrees());
    }

    private IEnumerator SpawnTrees()
    {
        while (true)
        {
            GameObject randomTree = treePrefabs[Random.Range(0, treePrefabs.Length)];
            Vector3 spawnPosition = (Random.value < 0.5f) ?
                new Vector3(-10, 0, zSpawnPositions[Random.Range(0, zSpawnPositions.Length)]) :
                new Vector3(10, 0, zSpawnPositions[Random.Range(0, zSpawnPositions.Length)]);
            Instantiate(randomTree, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
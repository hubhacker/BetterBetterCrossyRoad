using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lambdaSpawner : MonoBehaviour
{
    public GameObject leftLambdaPrefab;
    public GameObject rightLambdaPrefab; 
    public float spawnInterval = 1f; // Time between spawns

    public int[] zSpawnPositions = {1, 2, 4, 9};

    private void Start()
    {
        for(int i = 0; i < 4; i++){
            int randomIndex = Random.Range(0, 2);
            if(randomIndex == 0){
                Vector3 spawnPositionLeft = new Vector3(-10, 1, zSpawnPositions[i]);
                Instantiate(leftLambdaPrefab, spawnPositionLeft, Quaternion.identity);
            }
            else{
                Vector3 spawnPositionRight = new Vector3(10, 1, zSpawnPositions[i]);
                Instantiate(rightLambdaPrefab, spawnPositionRight, Quaternion.identity);
            }
        }
        StartCoroutine(SpawnLambdas());
    }

    private IEnumerator SpawnLambdas()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, 2);
            if(randomIndex == 0){
                Vector3 spawnPositionLeft = new Vector3(-10, 1, zSpawnPositions[Random.Range(0, zSpawnPositions.Length)]);
                Instantiate(leftLambdaPrefab, spawnPositionLeft, Quaternion.identity);
            }
            else{
                Vector3 spawnPositionRight = new Vector3(10, 1, zSpawnPositions[Random.Range(0, zSpawnPositions.Length)]);
                Instantiate(rightLambdaPrefab, spawnPositionRight, Quaternion.identity);
            }


            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
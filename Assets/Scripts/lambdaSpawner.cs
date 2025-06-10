using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lambdaSpawner : MonoBehaviour
{
    public GameObject leftLambdaPrefab;
    public GameObject rightLambdaPrefab; 
    public float spawnInterval = 1f; // Time between spawns

    public int[] zSpawnPositions = {1, 2, 3, 7, 10, 13, 14};
    public List<int> zSpawnPositionsRight = new List<int>();
    public List<int> zSpawnPositionsLeft = new List<int>();
    public float minSpeed = 1f;
    public float maxSpeed = 4f;

    public void IncreaseLambdaSpeed(float increment = 0.5f)
    {
        minSpeed += increment;
        maxSpeed += increment;
        Debug.Log($"Lambda speed increased: {minSpeed} - {maxSpeed}");
    }

    private GameObject SpawnLambda(GameObject prefab, Vector3 position)
    {
        GameObject lambda = Instantiate(prefab, position, Quaternion.identity);
        
        // Set random speed inside the prefab’s movement script
        if (lambda.TryGetComponent<leftLambdaMovement>(out var left))
        {
            left.speed = Random.Range(minSpeed, maxSpeed);
        }
        else if (lambda.TryGetComponent<rightLambdaMovement>(out var right))
        {
            right.speed = Random.Range(minSpeed, maxSpeed);
        }

        return lambda;
    }


    private void Start()
    {
        for(int i = 0; i < zSpawnPositions.Length; i++){
            Debug.Log("zSpawnPositions: " + zSpawnPositions[i]);
            int randomIndex = Random.Range(0, 2);
            int z = zSpawnPositions[i];
            Vector3 spawnPos = (randomIndex == 0) ? new Vector3(-10, 1, z) : new Vector3(10, 1, z);

            if (randomIndex == 0)
            {
                zSpawnPositionsLeft.Add(z);
                Destroy(SpawnLambda(leftLambdaPrefab, spawnPos), 15f);
            }
            else
            {
                zSpawnPositionsRight.Add(z);
                Destroy(SpawnLambda(rightLambdaPrefab, spawnPos), 15f);
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
                Vector3 spawnPositionLeft = new Vector3(-10, 1, zSpawnPositionsLeft[Random.Range(0, zSpawnPositionsLeft.Count)]);
                Destroy(Instantiate(leftLambdaPrefab, spawnPositionLeft, Quaternion.identity), 15f);
            }
            else{
                Vector3 spawnPositionRight = new Vector3(10, 1, zSpawnPositionsRight[Random.Range(0, zSpawnPositionsRight.Count)]);
                Destroy(Instantiate(rightLambdaPrefab, spawnPositionRight, Quaternion.identity), 15f);
            }


            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void addZSpawnPosition(int zPosition){
        int randomIndex = Random.Range(0, 2);
        if(randomIndex == 0){
            zSpawnPositionsLeft.Add(zPosition);
            Vector3 spawnPositionLeft = new Vector3(-10, 1, zPosition);
            Instantiate(leftLambdaPrefab, spawnPositionLeft, Quaternion.identity);
        }
        else{
            zSpawnPositionsRight.Add(zPosition);
            Vector3 spawnPositionRight = new Vector3(10, 1, zPosition);
            Instantiate(rightLambdaPrefab, spawnPositionRight, Quaternion.identity);
        }
    }
}
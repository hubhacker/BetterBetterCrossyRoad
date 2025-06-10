using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject[] worldPrefabs; // Assign your tile prefabs in the Inspector
    public Transform chicken;         // Assign the Chicken GameObject
    public float spawnOffset = 15f;   // How far ahead of the chicken to spawn tiles

    private int lastGeneratedZ = int.MinValue;

    // Update is called once per frame
    void Update()
    {
        int currentZ = Mathf.FloorToInt(chicken.position.z);

        if (currentZ > lastGeneratedZ)
        {
            lastGeneratedZ = currentZ;

            GameObject prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length)];

            Vector3 spawnPosition = new Vector3(0, 0, currentZ + spawnOffset);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}

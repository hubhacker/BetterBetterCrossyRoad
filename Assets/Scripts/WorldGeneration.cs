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
        // Round down the chicken's Z position to the nearest whole unit
        int currentZ = Mathf.FloorToInt(chicken.position.z);

        // Only generate a tile if chicken moved into a new unit
        if (currentZ > lastGeneratedZ)
        {
            lastGeneratedZ = currentZ;

            // Choose a random tile prefab
            GameObject prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length)];

            // Spawn it 15 units ahead on the Z axis
            Vector3 spawnPosition = new Vector3(0, 0, currentZ + spawnOffset);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}

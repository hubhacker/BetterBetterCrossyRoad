using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject[] worldPrefabs;
    public Transform chicken;
    public float spawnDistance = 15f;
    private int farthestChickenDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        farthestChickenDistance = (int) Mathf.Round(chicken.position.z);
        GenerateNextTile();
    }

    // Update is called once per frame
    void Update()
    {
        int chickenZ = (int) Mathf.Round(chicken.position.z);;

        if (chickenZ >= farthestChickenDistance)
        {
            farthestChickenDistance = chickenZ;
            GenerateNextTile();
        }
    }

    void GenerateNextTile()
    {
        GameObject prefab = worldPrefabs[Random.Range(0, worldPrefabs.Length)];

        Vector3 spawnPosition = new Vector3(0, 0, farthestChickenDistance + spawnDistance);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}

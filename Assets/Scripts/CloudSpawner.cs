using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public ChickenMovement chicken;
    public float spawnInterval = 1f;
    public float minSpeed = 1f;
    public float maxSpeed = 4f;
    [SerializeField] public GameObject[] cloudPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        chicken = GetComponent<ChickenMovement>();
        // StartCoroutine(TestSpawn());
        StartCoroutine(SpawnClouds());
    }

    IEnumerator TestSpawn()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(0, 10, 0);
            SpawnCloud(cloudPrefabs[0], pos);
            yield return new WaitForSeconds(1f);
        }
    }

    private GameObject SpawnCloud(GameObject prefab, Vector3 position)
    {
        GameObject cloud = Instantiate(prefab, position, Quaternion.identity);
        Debug.Log("Spawned cloud at position: " + position);

        CloudMover movement = cloud.GetComponent<CloudMover>();
        movement.speed = Random.Range(minSpeed, maxSpeed);
        movement.direction = (Random.value > 0.5f) ? 1 : -1;

        return cloud;
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];
            Vector3 spawnPosition;
            int direction = (Random.value > 0.5f) ? 1 : -1;

            if (direction == 1)
            {
                spawnPosition = new Vector3(-40, 10, Random.Range(chicken.transform.position.z - 5, chicken.transform.position.z + 15));
            }
            else
            {
                spawnPosition = new Vector3(40, 10, Random.Range(chicken.transform.position.z - 5, chicken.transform.position.z + 15));
            }

            GameObject cloud = SpawnCloud(cloudPrefab, spawnPosition);
            CloudMover movement = cloud.GetComponent<CloudMover>();

            Destroy(cloud, 35f);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

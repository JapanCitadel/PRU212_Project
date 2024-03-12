using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSpawner : MonoBehaviour
{
    public GameObject boomPrefab;
    public float spawnInterval = 7f; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBoom();
            timer = 0f; 
        }
    }

    void SpawnBoom()
    {
        float randomX = Random.Range(-8f, 8f); 
        Vector2 spawnPosition = new Vector2(randomX, 6f); 

        GameObject newBoom = Instantiate(boomPrefab, spawnPosition, Quaternion.identity);
        newBoom.AddComponent<BoomController>(); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    float time = 0f;
    float ScreenWidth, ScreenHeight;
    float xPosition, yPosition;
    List<GameObject> enemies;
    EnemyMovement script;
    [SerializeField]
    int poolSize;

    void Start()
    {
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        ScreenHeight = Camera.main.orthographicSize;
        enemies = new List<GameObject>();
        if (gameObject.tag == "Enemy")
        {
            poolSize = 20;
        }
        else if (gameObject.tag == "Enemy2")
        {
            poolSize = 15;
        }
        else if (gameObject.tag == "Enemy3")
        {
            poolSize = 10;
        }
        else
        {
            poolSize = 5;
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            SpawnEnemy(1f);
        }
        else if (gameObject.tag == "Enemy2")
        {
            SpawnEnemy(3f);
        }
        else if (gameObject.tag == "Enemy3")
        {
            SpawnEnemy(5f);
        }
        else
        {
            SpawnEnemy(10f);
        }
    }

    void SpawnEnemy(float spawnTime)
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            GameObject enemy = GetFreeEnemy();
            if (enemy != null)
            {
                Vector2 enemyPosition = new Vector2(Random.Range(0, 2) == 0 ? ScreenWidth : -ScreenWidth, Random.Range(-ScreenHeight, ScreenHeight));
                enemy.transform.position = enemyPosition;

                EnemyMovement script = enemy.GetComponent<EnemyMovement>();
                if (script != null)
                {
                    script.SetXDirection(Random.Range(0, 2) == 0 ? -1 : 1); // Set random direction
                    script.SetXSpeed(Random.Range(1, 5)); // Set random speed
                }
            }
            time = 0;
        }
    }

    GameObject GetFreeEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf == false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
}

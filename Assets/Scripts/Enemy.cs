using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject prefabs;
    float time;
    float xScreenWidth;
    float yScreenHeight;
    List<GameObject> enemies;
    EnemyMovement script;

    void Start()
    {
        xScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        yScreenHeight = Camera.main.orthographicSize;
        enemies = new List<GameObject>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            time -= 3;

            GameObject enemy = Instantiate(prefabs);
            enemy.SetActive(true);
            enemies.Add(enemy);

            float yPosition = Random.Range(-yScreenHeight, yScreenHeight);
            float xPosition = Random.Range(0, 2) == 0 ? -xScreenWidth : xScreenWidth;

            enemy.transform.position = new Vector2(xPosition, yPosition);

            script = enemy.GetComponent<EnemyMovement>();
            if (script != null)
            {
                float xSpeed = Random.Range(1, 10);
                float ySpeed = Random.Range(1, 10);

                int xDirectionRandom = (xPosition < 0) ? 1 : -1; 
                int yDirectionRandom = Random.Range(0, 2) * 2 - 1; 

                script.SetXDirection(xDirectionRandom);
                script.SetYDirection(yDirectionRandom);
                script.SetSpeed(xSpeed, ySpeed);
            }
        }
    }

    GameObject GetFresEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf == false && enemies != null)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
}

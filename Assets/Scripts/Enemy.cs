using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    float time;
    float xScreenWidth;
    float yScreenHeight;
    int poolsize = 4;
    List<GameObject> enemies;
    EnemyMovement script;

    void Start()
    {
        xScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        yScreenHeight = Camera.main.orthographicSize;
        enemies = new List<GameObject>();
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            GameObject enemy = GetFresEnemy();


            float[] xPositions = { -xScreenWidth , xScreenWidth  };

            float randomXPosition = xPositions[Random.Range(0, 2)];

            float yPosition = Random.Range(-yScreenHeight , yScreenHeight );

            enemy.transform.position = new Vector2(randomXPosition, yPosition);

            script = enemy.GetComponent<EnemyMovement>();
            if (script != null)
            {
                if (Random.Range(1, 100) < 50)
                    script.SetXDirection(1);
                else
                    script.SetXDirection(-1);

                script.SetXSpeed(Random.Range(1, 10));
                time = 0;
            }
        }

        // Kiểm tra vị trí của từng quái vật và deactive chúng nếu chúng ra khỏi màn hình
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && IsOutOfScreen(enemy.transform.position))
            {
                enemy.SetActive(false);
            }
        }
    }

    GameObject GetFresEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }

    bool IsOutOfScreen(Vector3 position)
    {
        // Kiểm tra xem vị trí có nằm ngoài màn hình không
        return position.x < -xScreenWidth || position.x > xScreenWidth || position.y < -yScreenHeight || position.y > yScreenHeight;
    }
}

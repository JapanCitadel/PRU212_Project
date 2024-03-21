using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    GameObject prefab;
    float time;
    float xScreenWidth;
    float yScreenHeight;
    int poolsize = 4;
=======
    GameObject prefabs;
    float time;
    float xScreenWidth;
    float yScreenHeight;
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    List<GameObject> enemies;
    EnemyMovement script;

    void Start()
    {
        xScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        yScreenHeight = Camera.main.orthographicSize;
        enemies = new List<GameObject>();
<<<<<<< HEAD
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
=======
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
<<<<<<< HEAD
            GameObject enemy = GetFresEnemy();


            float[] xPositions = { -xScreenWidth , xScreenWidth  };

            float randomXPosition = xPositions[Random.Range(0, 2)];

            float yPosition = Random.Range(-yScreenHeight , yScreenHeight );

            enemy.transform.position = new Vector2(randomXPosition, yPosition);
=======
            time -= 3;

            GameObject enemy = Instantiate(prefabs);
            enemy.SetActive(true);
            enemies.Add(enemy);

            float yPosition = Random.Range(-yScreenHeight, yScreenHeight);
            float xPosition = Random.Range(0, 2) == 0 ? -xScreenWidth : xScreenWidth;

            enemy.transform.position = new Vector2(xPosition, yPosition);
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f

            script = enemy.GetComponent<EnemyMovement>();
            if (script != null)
            {
<<<<<<< HEAD
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
=======
                float xSpeed = Random.Range(1, 10);
                float ySpeed = Random.Range(1, 10);

                int xDirectionRandom = (xPosition < 0) ? 1 : -1; 
                int yDirectionRandom = Random.Range(0, 2) * 2 - 1; 

                script.SetXDirection(xDirectionRandom);
                script.SetYDirection(yDirectionRandom);
                script.SetSpeed(xSpeed, ySpeed);
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
            }
        }
    }

    GameObject GetFresEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
<<<<<<< HEAD
            if (!enemy.activeSelf)
=======
            if (enemy.activeSelf == false && enemies != null)
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
<<<<<<< HEAD

    bool IsOutOfScreen(Vector3 position)
    {
        // Kiểm tra xem vị trí có nằm ngoài màn hình không
        return position.x < -xScreenWidth || position.x > xScreenWidth || position.y < -yScreenHeight || position.y > yScreenHeight;
    }
=======
>>>>>>> 2c1c6c604d9d01330df1ed2058bbdbcd3ec9e90f
}

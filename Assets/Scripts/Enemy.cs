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

            float yPosition = Random.Range(-yScreenHeight, yScreenHeight); // Random yPosition trong khoảng từ -yScreenHeight đến yScreenHeight (toàn bộ chiều cao của màn hình)
            enemy.transform.position = new Vector2(
                Random.Range(-xScreenWidth, xScreenWidth), yPosition);

            script = enemy.GetComponent<EnemyMovement>();
            if (script != null)
            {
                float xSpeed = Random.Range(1, 10);
                float ySpeed = Random.Range(1, 10);

                if (Random.Range(1, 100) < 50)
                    script.SetXDirection(1);
                else
                    script.SetXDirection(-1);

                if (Random.Range(1, 100) < 50)
                    script.SetYDirection(1);
                else
                    script.SetYDirection(-1);

                script.SetSpeed(xSpeed, ySpeed);
            }
        }
    }
}

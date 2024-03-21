using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class BoomSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public float spawnTime; 
    float time = 0f;
    float ScreenWidth, ScreenHeight;
    float xPosition, yPosition;
    [SerializeField]
    int poolSize;
    List<GameObject> Bombs;

    void Start()
    {
        ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        ScreenHeight = Camera.main.orthographicSize * 2 + 10;
        Bombs = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomb = Instantiate(bombPrefab);
            bomb.SetActive(false);
            Bombs.Add(bomb);
        }
    }
    void Update()
    {
        SpawnBoom();
    }

    void SpawnBoom()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            GameObject bomb = GetFreeBomb();
            if (bomb != null)
            {
                xPosition = Random.Range(0, 2) == 0 ? ScreenWidth : -ScreenWidth;
                yPosition = ScreenHeight;
                Vector2 bombPosition = new Vector2(xPosition, yPosition);
                bomb.transform.position = bombPosition;

                BoomController script = bomb.GetComponent<BoomController>();
                if (script != null)
                {
                    script.SetFallSpeed(Random.Range(3, 6));
                }
            }
            time = 0;
        }
    }

    GameObject GetFreeBomb()
    {
        foreach (GameObject bomb in Bombs)
        {
            if (bomb.activeSelf == false)
            {
                bomb.SetActive(true);
                return bomb;
            }
        }
        return null;
    }
}

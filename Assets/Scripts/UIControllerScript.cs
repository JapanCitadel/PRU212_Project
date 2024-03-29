using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    int totalTime = 60;
    Text txtTime, txtEnemyCount, txtScore;
    float time = 0;
    public int EnemyCount = 0;
    public int Score = 0;
    public static bool isPause = false;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        txtTime = canvas.transform.Find("txtTime").GetComponent<Text>();
        txtTime.text = totalTime.ToString();
        txtEnemyCount = canvas.transform.Find("txtEnemyCount").GetComponent<Text>();
        txtEnemyCount.text = EnemyCount.ToString();
        txtScore = canvas.transform.Find("txtScore").GetComponent<Text>();
        txtScore.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            totalTime -= 1;
            txtTime.text = totalTime.ToString();
            time = 0;
            if (totalTime == 0)
            {
                PlayerPrefs.SetInt("EnemyCount", EnemyCount);
                PlayerPrefs.SetInt("Score", Score);
                SceneManager.LoadScene(5);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnemyIncreasement(string EnemyTag)
    {
        EnemyCount += 1;
        txtEnemyCount.text = EnemyCount.ToString();
        int points = 0;
        switch (EnemyTag)
        {
            case "Enemy":
                points = 10;
                break;
            case "Enemy2":
                points = 20;
                break;
            case "Enemy3":
                points = 40;
                break;
            case "Enemy4":
                points = 80;
                break;
            default:
                points = 0;
                break;
        }

        Score += points;
        txtScore.text = Score.ToString();
    }
}

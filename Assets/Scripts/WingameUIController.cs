using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WingameUIController : MonoBehaviour
{
    [SerializeField]
    Text txtEnemyCount, txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtEnemyCount.text = "" + PlayerPrefs.GetInt("EnemyCount");
        txtScore.text = "" + PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }
}

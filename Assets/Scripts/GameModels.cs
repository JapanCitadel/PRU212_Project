using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EasyMode()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void HardMode()
    {
        SceneManager.LoadSceneAsync(4);
    }

}

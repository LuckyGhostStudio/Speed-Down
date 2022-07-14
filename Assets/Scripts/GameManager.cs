using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public GameObject gameOverUI;
    public GameObject timeUI;

    public Text timeScore;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }

    void Update()
    { 
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }

    public void RestartGame()       //重新开始
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()              //退出
    {
        Application.Quit();
    }

    public static void GameOver(bool dead)
    {
        if (dead)
        {
            instance.gameOverUI.SetActive(true);
            Time.timeScale = 0f;    //暂停
        }
    }
}

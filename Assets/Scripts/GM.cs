using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    GameObject canvas;

    // µ¥Àý¶ÔÏó
    public static GM Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }

    public void OnPlayerDie()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
    public void OnRestartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void OnBackToTitleBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}

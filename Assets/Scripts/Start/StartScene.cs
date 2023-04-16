using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip startSound;

    bool enterGame = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartBtn()
    {
        // 防连击
        if (enterGame)
        {
            return;
        }
        // 播放音效
        audioSource.clip = startSound;
        audioSource.Play();
        enterGame = true;

        // 开启协程
        StartCoroutine(CoGameStart());
    }

    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("StartGameBtn");
        // 开始按钮闪烁
        for (int i = 0; i < 6; ++i)
        {
            // 可见性取反
            btn.SetActive(!btn.activeInHierarchy);
            // 等待
            yield return new WaitForSeconds(0.3f);
        }

        // 切换场景
        SceneManager.LoadScene("Game");
    }
}

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
        // ������
        if (enterGame)
        {
            return;
        }
        // ������Ч
        audioSource.clip = startSound;
        audioSource.Play();
        enterGame = true;

        // ����Э��
        StartCoroutine(CoGameStart());
    }

    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("StartGameBtn");
        // ��ʼ��ť��˸
        for (int i = 0; i < 6; ++i)
        {
            // �ɼ���ȡ��
            btn.SetActive(!btn.activeInHierarchy);
            // �ȴ�
            yield return new WaitForSeconds(0.3f);
        }

        // �л�����
        SceneManager.LoadScene("Game");
    }
}

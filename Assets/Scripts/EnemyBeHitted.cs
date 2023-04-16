using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHitted : MonoBehaviour
{
    SpriteRenderer[] renders;
    // �ܻ�ʱ���ֺ�ɫ��ʱ��
    public float redTime = 0.05f;
    // ���ԭɫ��ʱ��
    float changeColorTime;
    // ����Ѫ��
    public int hp = 10;
    // ������ը����
    public Transform prefabEnemyExplosion;
    void Start()
    {
        // �������������������Ӧ���������
        renders = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
    }

    void SetColor(Color c)
    {
        if (renders[0].color == c)
        {
            return;
        }
        foreach (var r in renders)
        {
            r.color = c;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;

        if (--hp <= 0)
        {
            // ����������ը��Ч
            if (prefabEnemyExplosion)
            {
                Instantiate(prefabEnemyExplosion, transform.position, Quaternion.identity);
            }
            // ��������
            Destroy(gameObject);
        }
    }
}

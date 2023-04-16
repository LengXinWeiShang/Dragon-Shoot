using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHitted : MonoBehaviour
{
    SpriteRenderer[] renders;
    // 受击时保持红色的时间
    public float redTime = 0.05f;
    // 变回原色的时间
    float changeColorTime;
    // 敌人血量
    public int hp = 10;
    // 死亡爆炸动画
    public Transform prefabEnemyExplosion;
    void Start()
    {
        // 包含自身及所有子物体对应的组件数组
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
            // 播放死亡爆炸特效
            if (prefabEnemyExplosion)
            {
                Instantiate(prefabEnemyExplosion, transform.position, Quaternion.identity);
            }
            // 销毁自身
            Destroy(gameObject);
        }
    }
}

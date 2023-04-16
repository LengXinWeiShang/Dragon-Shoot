using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 子弹速度
    public float speed = 6;
    // 爆炸图预制体
    public Transform prefabExpl;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 代表变量指向有效的游戏物体，若写成 prefabExpl != null，则不一定指向有效的游戏物体
        if (prefabExpl)
        {
            Transform expl = Instantiate(prefabExpl, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 敌人移动速度
    public float speed = 3;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}

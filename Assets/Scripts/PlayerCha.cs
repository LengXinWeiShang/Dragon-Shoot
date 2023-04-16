using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : MonoBehaviour
{
    // 子弹预制体
    public Transform prefabBullet;
    // 玩家移动速度
    public float speed = 3;
    // 射击间隔
    public float fireCD = 0.15f;
    // 上一次射击时间
    float lastFireTime;
    // 玩家能够移动的边界
    public Border moveBorder;
    // GM
    GM gm;
    // Start is called before the first frame update
    void Start()
    {
        lastFireTime = -fireCD;
        gm = GM.Instance;
    }

    public void Move(Vector3 input)
    {
        Vector3 newPos = transform.position + input * speed * Time.deltaTime;
        // Clmap：限定范围 第一参数为待限定的数，第二个参数为左边界，第三个参数为右边界
        newPos.x = Mathf.Clamp(newPos.x, moveBorder.left, moveBorder.right);
        newPos.y = Mathf.Clamp(newPos.y, moveBorder.bottom, moveBorder.top);
        transform.position = newPos;
    }

    public void Fire()
    {
        if (Time.time < lastFireTime + fireCD)
        {
            return;
        }
        Vector3 pos = transform.position + new Vector3(0, 1, 0);
        Transform bullet = Instantiate(prefabBullet, pos, Quaternion.identity);
        lastFireTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        gm.OnPlayerDie();
    }
}

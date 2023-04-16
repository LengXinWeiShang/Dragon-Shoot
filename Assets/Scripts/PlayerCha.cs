using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : MonoBehaviour
{
    // �ӵ�Ԥ����
    public Transform prefabBullet;
    // ����ƶ��ٶ�
    public float speed = 3;
    // ������
    public float fireCD = 0.15f;
    // ��һ�����ʱ��
    float lastFireTime;
    // ����ܹ��ƶ��ı߽�
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
        // Clmap���޶���Χ ��һ����Ϊ���޶��������ڶ�������Ϊ��߽磬����������Ϊ�ұ߽�
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

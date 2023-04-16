using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �ӵ��ٶ�
    public float speed = 6;
    // ��ըͼԤ����
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
        // �������ָ����Ч����Ϸ���壬��д�� prefabExpl != null����һ��ָ����Ч����Ϸ����
        if (prefabExpl)
        {
            Transform expl = Instantiate(prefabExpl, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

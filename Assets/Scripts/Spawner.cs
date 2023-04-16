using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // �����ǵ�Ԥ����
    public List<Transform> prefabMonsters;
    // �����ˢ�¼��
    public float minTime = 0.5f;
    public float maxTime = 2;
    void Start()
    {
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            // ��һ��ʱ��
            float t = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(t);
            // ��������
            // ����±�
            int i = Random.Range(0, prefabMonsters.Count);
            // ���λ��
            Vector3 pos = new Vector3(Random.Range(-2.1f, 2.1f), 7, 0);
            Instantiate(prefabMonsters[i], pos, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    // ö��״̬����������֮�ڣ���Ϊֻ��������õ�
    enum State
    {
        Down,
        LeftRight,
    }
    // ��ʼ״̬
    State state = State.Down;
    // �߽�
    public float minY = 2.6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;
    // �ٶ�
    public float speed = 1.5f;

    void Update()
    {
        switch (state)
        {
            case State.Down:
                {
                    transform.position += Vector3.down * 3 * Time.deltaTime;
                    if (transform.position.y <= minY)
                    {
                        state = State.LeftRight;
                    }
                }
                break;
            case State.LeftRight:
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    if (transform.position.x <= minX)
                    {
                        speed = -Mathf.Abs(speed);
                    }
                    if (transform.position.x >= maxX)
                    {
                        speed = Mathf.Abs(speed);
                    }
                }
                break;
            default:
                break;
        }
    }
}
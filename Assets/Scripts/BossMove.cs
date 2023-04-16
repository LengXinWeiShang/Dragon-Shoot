using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    // 枚举状态，定义在类之内，因为只有这个类用到
    enum State
    {
        Down,
        LeftRight,
    }
    // 初始状态
    State state = State.Down;
    // 边界
    public float minY = 2.6f;
    public float minX = -2.3f;
    public float maxX = 2.3f;
    // 速度
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

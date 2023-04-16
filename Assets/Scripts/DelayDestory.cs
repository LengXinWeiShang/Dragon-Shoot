using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestory : MonoBehaviour
{
    public float destoryTime = 1;
    float createTime;
    private void Start()
    {
        createTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - createTime >= destoryTime)
        {
            Destroy(gameObject);
        }
    }
}

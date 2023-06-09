using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    Material mat;
    public float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        // sharedMaterial：挂了同一个材质的物体一起变
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //相機要跟隨的物件
    private Vector3 offset;    //相機和跟隨物件的距離
    private void Awake()
    {
        offset = transform.position - target.transform.position;    //相機和跟隨物件的距離
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;    //相機的位置在固定距離
    }
}

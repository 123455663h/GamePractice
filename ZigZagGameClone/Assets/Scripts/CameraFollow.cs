using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //�۾��n���H������
    private Vector3 offset;    //�۾��M���H���󪺶Z��
    private void Awake()
    {
        offset = transform.position - target.transform.position;    //�۾��M���H���󪺶Z��
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;    //�۾�����m�b�T�w�Z��
    }
}

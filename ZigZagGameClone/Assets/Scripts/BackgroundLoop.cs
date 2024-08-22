using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop instance;

    private void Awake()
    {
        if (instance == null)    //�p�G�O�ŭȪ��� �ͦ�
        {
            instance = this;
        }
        else if (instance != this)    //�p�G�w�g���@�Ӫ���  �R��Ѥ@��
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);    //�������ɤ��R��
    }
}

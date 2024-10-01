using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop instance;

    private void Awake()
    {
        if (instance == null)    //如果是空值的話 生成
        {
            instance = this;
        }
        else if (instance != this)    //如果已經有一個的話  刪到剩一個
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);    //換場景時不刪除
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;    //最小移動距離

    private Rigidbody2D rb;
    private Collider2D col;

    private Vector3 lastMousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()    //用update反而會讀太快而讀不到
    {
        col.enabled = IsMouseMoving();    //移動就會打開碰撞，不移動不會

        SetBladeToMouse();
    }

    private void SetBladeToMouse()    //滑鼠滑過會有砍過去的痕跡
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;    //因為遊戲是2D的但滑鼠是3D的所以要設定Z軸

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);    //偵測滑鼠滑到哪這個物件的位置就跟到哪
    }

    private bool IsMouseMoving()    //確認刀有沒有在移動，沒有就不會切到水果
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;    //magnitude 計算最短距離
        lastMousePos = curMousePos;
        if (traveled > minVelo)
        {
            return true;
        }
        else 
        { 
            return false;
        }
    }
}

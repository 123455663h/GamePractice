using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)    //如果刀刃沒碰到炸彈(這個腳本的物件)的話 沒事發生
        {
            return;
        }
        FindObjectOfType<GameManager>().OnBombHit();    //碰到的話觸發GameManager裡的自訂函式
    }
}

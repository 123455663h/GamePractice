using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForObjects : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //判斷滑鼠的座標  回傳滑鼠碰到的物件名稱 被ray打到的物件需要有Collider

        RaycastHit hit;    //RaycastHit是指被射線ray打到的物體，畫出攝影機到物體的線，並且顯示hit的名稱。
        if (Physics.Raycast(ray, out hit , 100))
        {
            print("hit" + hit.collider.gameObject);
        }
    }
}

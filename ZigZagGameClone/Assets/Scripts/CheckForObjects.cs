using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForObjects : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //�P�_�ƹ����y��  �^�Ƿƹ��I�쪺����W�� �Qray���쪺����ݭn��Collider

        RaycastHit hit;    //RaycastHit�O���Q�g�uray���쪺����A�e�X��v���쪫�骺�u�A�åB���hit���W�١C
        if (Physics.Raycast(ray, out hit , 100))
        {
            print("hit" + hit.collider.gameObject);
        }
    }
}

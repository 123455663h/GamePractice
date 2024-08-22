using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;    //�̤p���ʶZ��

    private Rigidbody2D rb;
    private Collider2D col;

    private Vector3 lastMousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()    //��update�Ϧӷ|Ū�ӧ֦�Ū����
    {
        col.enabled = IsMouseMoving();    //���ʴN�|���}�I���A�����ʤ��|

        SetBladeToMouse();
    }

    private void SetBladeToMouse()    //�ƹ��ƹL�|����L�h������
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;    //�]���C���O2D�����ƹ��O3D���ҥH�n�]�wZ�b

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);    //�����ƹ��ƨ���o�Ӫ��󪺦�m�N����
    }

    private bool IsMouseMoving()    //�T�{�M���S���b���ʡA�S���N���|������G
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude;    //magnitude �p��̵u�Z��
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

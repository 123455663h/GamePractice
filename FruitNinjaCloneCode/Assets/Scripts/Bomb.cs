using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)    //�p�G�M�b�S�I�쬵�u(�o�Ӹ}��������)���� �S�Ƶo��
        {
            return;
        }
        FindObjectOfType<GameManager>().OnBombHit();    //�I�쪺��Ĳ�oGameManager�̪��ۭq�禡
    }
}

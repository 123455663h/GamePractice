using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuild : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;    //�q�̫�@�Ӹ�����}�l����[��
    public float offset = 0.7071068f;    //�C�Ӹ����󶡶Z

    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart",1f,1);    //��GameManager�ӹB�@�o�Ӹ}��
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0,100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);    //�p�G�ü�<50�A���e�[��
        }
        else
            spawnPos = new Vector3(lastPos.x - offset , lastPos.y , lastPos.z + offset);

        GameObject g = Instantiate(roadPrefab,spawnPos, Quaternion.Euler(0,45,0));    //�q�̫�@�Ӹ������H�������Ω��e�ͦ�

        lastPos = g.transform.position;    //�̫�@�Ӹ����󬰷s�ͦ�������

        roadCount++;
        if (roadCount % 5 == 0)    //�C5�ӷs��������N�|�X�{����
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

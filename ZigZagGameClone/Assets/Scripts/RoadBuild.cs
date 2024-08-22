using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuild : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;    //從最後一個路物件開始往後加長
    public float offset = 0.7071068f;    //每個路物件間距

    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart",1f,1);    //用GameManager來運作這個腳本
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0,100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);    //如果亂數<50，往前加長
        }
        else
            spawnPos = new Vector3(lastPos.x - offset , lastPos.y , lastPos.z + offset);

        GameObject g = Instantiate(roadPrefab,spawnPos, Quaternion.Euler(0,45,0));    //從最後一個路物件隨機往左或往前生成

        lastPos = g.transform.position;    //最後一個路物件為新生成的那個

        roadCount++;
        if (roadCount % 5 == 0)    //每5個新的路物件就會出現水晶
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

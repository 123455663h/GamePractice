using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objsToSpawn;    //生成的水果等物件
    public GameObject bomb;    //生成炸彈
    public Transform[] spawnPlaces;    //設定一個陣列，裡面是水果生成的地方
    public float minWait = 0.3f;    //最短的等待時間
    public float maxWait = 1f;    //最長的等待時間
    public float minForce = 12f;
    public float maxForce = 17f;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        { 
            yield return new WaitForSeconds(Random.Range(minWait,maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];    //從陣列裡找從哪個位置生成

            GameObject go = null;
            float p = Random.Range(0,100);    //炸彈生成機率
            if (p < 10)    //10%機率炸彈
            {
                go = bomb;
            }
            else    //90%機率其他物件
            {
                go = objsToSpawn[Random.Range(0, objsToSpawn.Length)];    //如果大於10的話生成炸彈以外的隨機物件
            }

            GameObject fruit = Instantiate(go,t.position,t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce) ,ForceMode2D.Impulse);    //給水果1個向上的力，還沒搞懂Force2D.Impulse
            Destroy(fruit, 5);
        }
    }
}

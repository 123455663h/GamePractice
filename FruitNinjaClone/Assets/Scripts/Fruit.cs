using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject SlicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(SlicedFruitPrefab,transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>();    //用陣列去找生成inst的這個物件下有幾個子物件
        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;     //隨機的角度
            r.AddExplosionForce(Random.Range(500,1000), transform.position, 5f);    //給子物件飛出去的力量(威力，位置，半徑)
        }

        FindObjectOfType<GameManager>().IncreaseScore(100);    //找到GameManager裡面的自訂函式

        Destroy(inst.gameObject,5);    //刪除被切過的水果    
        Destroy(gameObject); ;    //刪除原本的水果
    }

    private void OnTriggerEnter2D(Collider2D collision)    //要把水果設定成是Trigger
    {
        Blade b = collision.GetComponent<Blade>();    //有點不懂 
        if (!b)
        {
            return;
        }
        CreateSlicedFruit();
    }
}

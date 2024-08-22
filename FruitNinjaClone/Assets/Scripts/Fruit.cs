using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject SlicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(SlicedFruitPrefab,transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>();    //�ΰ}�C�h��ͦ�inst���o�Ӫ���U���X�Ӥl����
        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;     //�H��������
            r.AddExplosionForce(Random.Range(500,1000), transform.position, 5f);    //���l���󭸥X�h���O�q(�¤O�A��m�A�b�|)
        }

        FindObjectOfType<GameManager>().IncreaseScore(100);    //���GameManager�̭����ۭq�禡

        Destroy(inst.gameObject,5);    //�R���Q���L�����G    
        Destroy(gameObject); ;    //�R���쥻�����G
    }

    private void OnTriggerEnter2D(Collider2D collision)    //�n����G�]�w���OTrigger
    {
        Blade b = collision.GetComponent<Blade>();    //���I���� 
        if (!b)
        {
            return;
        }
        CreateSlicedFruit();
    }
}

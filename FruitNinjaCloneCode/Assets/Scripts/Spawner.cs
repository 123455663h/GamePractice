using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objsToSpawn;    //�ͦ������G������
    public GameObject bomb;    //�ͦ����u
    public Transform[] spawnPlaces;    //�]�w�@�Ӱ}�C�A�̭��O���G�ͦ����a��
    public float minWait = 0.3f;    //�̵u�����ݮɶ�
    public float maxWait = 1f;    //�̪������ݮɶ�
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

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];    //�q�}�C�̧�q���Ӧ�m�ͦ�

            GameObject go = null;
            float p = Random.Range(0,100);    //���u�ͦ����v
            if (p < 10)    //10%���v���u
            {
                go = bomb;
            }
            else    //90%���v��L����
            {
                go = objsToSpawn[Random.Range(0, objsToSpawn.Length)];    //�p�G�j��10���ܥͦ����u�H�~���H������
            }

            GameObject fruit = Instantiate(go,t.position,t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce) ,ForceMode2D.Impulse);    //�����G1�ӦV�W���O�A�٨S�d��Force2D.Impulse
            Destroy(fruit, 5);
        }
    }
}

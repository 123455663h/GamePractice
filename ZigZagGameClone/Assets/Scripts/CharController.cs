using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayStart;
    public GameObject crystalEffect;    //水晶特效

    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator anim;
    private GameManager gameManager;    //引用GameManager腳本

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    //實體化
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)    //如果還沒開始的話
        {
            return;    //不做任何事
        }
        else 
        {
            anim.SetTrigger("gameStarted");
        }
        rb.transform.position = transform.position + transform.forward * Time.deltaTime;    //角色移動 不一定要加rb
    }
    
    private void Update()   //如果放在上面的話會卡
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit ray;

        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }

        if (!Physics.Raycast(rayStart.position, -transform.up, out ray, Mathf.Infinity) && transform.position.y < 0.3)    //Raycast(位置,方向往下,,距離) 判斷位置以下是否有碰撞體
        {
            anim.SetTrigger("isFalling");
        }
    }

    private void Switch()
    {
        if (!gameManager.gameStarted)    //如果遊戲還沒開始，不能做任何事
        {
            return;
        }
        walkingRight = !walkingRight;
        if (walkingRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Crystal")
        {
            gameManager.IncreaseScore();    //呼叫gameManager的函式
            GameObject g = Instantiate(crystalEffect,rayStart.transform.position,Quaternion.identity);    //生成特效在碰到水晶時產生
            Destroy(other.gameObject);
            Destroy(g,2);
        }
    }
}

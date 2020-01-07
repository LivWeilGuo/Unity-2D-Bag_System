using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //组件
    Rigidbody2D rb;
    Animator anim;

    //参数
    float speed = 5;//速度
    [HideInInspector]
    public Vector2 movement;//移动值

    private void Awake()
    {
        //获取组件
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        SwitchAnim();
    }

    /// <summary>
    /// 移动方法
    /// </summary>
    void Movement()
    {
        //获得按键值
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //赋予角色移动
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    /// <summary>
    /// 动画的切换
    /// </summary>
    void SwitchAnim()
    {
        float speedSqrValue = movement.sqrMagnitude;
        if (movement != Vector2.zero)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }
        anim.SetFloat("speed", speedSqrValue);
    }
}

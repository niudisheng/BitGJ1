using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowableWeapon : Weapon
{
    private float offset = -90f;
    public bool isThrown = false;
    Vector3 difference;
    private Rigidbody2D rb;
    public float speed = 10f;

    private void Start()
    {
        
        rb = this.GetComponent<Rigidbody2D>();
    }

    protected override void onExecute()
    {
        if (isThrown)
        {
            Debug.LogWarning("Weapon is already thrown");
            //TODO:加入抛出动画和物理效果的代码
            
            rb.velocity = difference * speed;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;
        }
        else
        {
            //TODO:加入切换动画和攻击状态的代码
            
        }
    }

    private void turning()
    {
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle + offset);
        }
        else
        {

            //计算距离
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //计算角度
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //转向
            rb.MoveRotation(Quaternion.Euler(0f, 0f, rotZ + offset));
        }
        
        
    }

    private void Update()
    {
        if (isThrown)
        {
            turning();
        }
        
    }
}

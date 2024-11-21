using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowableWeapon : Weapon
{
    Vector3 originPosition;

    protected override void Start()
    {
        base.Start();
        originPosition = transform.localPosition;
    
    }

    private void turning()
    {
        //在移动时
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
            transform.localPosition = originPosition;
        }
        
        
    }

    private void Update()
    {
        if (!isThrown)
        {
            turning();
        }
        
    }
}

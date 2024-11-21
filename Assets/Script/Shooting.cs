using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Weapon
{
    //转向角度
    
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShorts;
    public float startTimeBtwLongs;

    private void Start()
    {
        
         var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
         spriteRenderer.sprite = projectile.GetComponent<SpriteRenderer>().sprite;
         
    }

    private void Update()
    {
        turning();
    }

    private void turning()
    {
        //计算距离
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //计算角度
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //转向
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
    }

    protected override void onExecute()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
        timeBtwShorts = startTimeBtwLongs;
        
    }
}

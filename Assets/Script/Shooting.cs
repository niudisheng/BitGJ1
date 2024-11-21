using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Weapon
{
    //ת��Ƕ�
    
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
        //�������
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //����Ƕ�
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //ת��
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
    }

    protected override void onExecute()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
        timeBtwShorts = startTimeBtwLongs;
        
    }
}
